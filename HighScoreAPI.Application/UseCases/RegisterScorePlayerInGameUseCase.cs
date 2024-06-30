using HighScoreAPI.Application.DTOs;
using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.Result;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.UseCases;

public class RegisterScorePlayerInGameUseCase
{
    private readonly IGameRepository _gameRepository;
    private readonly IHighScoreRepository _highscoreRepository;
    private readonly IPlayerRepository _playerRepository;

    public RegisterScorePlayerInGameUseCase(IGameRepository gamerepository, IPlayerRepository playerRepository, IHighScoreRepository highscoreRepository)
    {
        _gameRepository = gamerepository;
        _playerRepository = playerRepository;
        _highscoreRepository = highscoreRepository;
    }

    public async Task<OperationResult> Handle(RegisterScorePlayerInGameRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Game) || string.IsNullOrWhiteSpace(request.Username))
            {
                return new OperationResult(400, false, "Failed to insert the new score, check the fields and try again.");
            }

            var existingGame = await _gameRepository.FindByNameAsync(request.Game , request.DeveloperGame);
            if (existingGame == null)
            {
                return new OperationResult(400, false, "Game not exists.");
            }

            var existingPlayer = await _playerRepository.FindByUsernameAsync(request.Username);
            if (existingPlayer == null)
            {
                existingPlayer = new Player { Username = request.Username };
                await _playerRepository.AddAsync(existingPlayer);

                
                existingPlayer = await _playerRepository.FindByUsernameAsync(request.Username);
            }

            var existingHighScore = await _highscoreRepository.GetHighscoreByPlayerToGameAsync(existingGame.Id, existingPlayer.Id);
            if (existingHighScore != null)
            {
                existingHighScore.Score = request.Score;
                await _highscoreRepository.UpdateAsync(existingHighScore);
            }
            else
            {
                var newHighScore = new highscore 
                {
                    PlayerId = existingPlayer.Id,
                    GameId = existingGame.Id,
                    Score = request.Score
                };
                await _highscoreRepository.AddAsync(newHighScore);
            }
            var Success = new OperationResult(200, true, "Score registered successfully");
            Success.Data = new ScoreDTO(existingPlayer.Username, existingGame.Name, existingGame.Developer, request.Score);
            return Success;
        }
        catch (Exception ex)
        {
            return new OperationResult(500, false, $"An internal error occurred. Please try again later. details: {ex.Message}");
        }
    }
}