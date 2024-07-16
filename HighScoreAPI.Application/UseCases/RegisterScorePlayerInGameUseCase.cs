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

    public RegisterScorePlayerInGameUseCase(IGameRepository gameRepository, IPlayerRepository playerRepository, IHighScoreRepository highscoreRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
        _highscoreRepository = highscoreRepository;
    }

    public async Task<OperationResult> Handle(RegisterScorePlayerInGameRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Game) || string.IsNullOrWhiteSpace(request.Username))
        {
            return new OperationResult(400, false, "Failed to insert the new score, check the fields and try again.");
        }

        var existingGame = await _gameRepository.FindByNameAsync(request.Game, request.DeveloperGame);
        if (existingGame == null)
        {
            return new OperationResult(400, false, "Game not exists.");
        }

        var player = await EnsurePlayerExists(request.Username);
        await EnsureHighScoreExistsOrUpdate(existingGame.Id, player.Id, request.Score);

        var result = new OperationResult(200, true, "Score registered successfully");
        result.SetData(new ScoreDTO(player.Username, existingGame.Name, existingGame.Developer, request.Score));
        return result;
    }

    private async Task<Player> EnsurePlayerExists(string username)
    {
        var existingPlayer = await _playerRepository.FindByUsernameAsync(username);
        if (existingPlayer == null)
        {
            var newPlayer = new Player { Username = username };
            await _playerRepository.AddAsync(newPlayer);
            return newPlayer;
        }
        return existingPlayer;
    }

    private async Task EnsureHighScoreExistsOrUpdate(int gameId, int playerId, double score)
    {
        var existingHighScore = await _highscoreRepository.GetHighscoreByPlayerToGameAsync(gameId, playerId);
        if (existingHighScore != null)
        {
            existingHighScore.Score = score;
            await _highscoreRepository.UpdateAsync(existingHighScore);
        }
        else
        {
            var newHighScore = new HighScore
            {
                PlayerId = playerId,
                GameId = gameId,
                Score = score
            };
            await _highscoreRepository.AddAsync(newHighScore);
        }
    }
}