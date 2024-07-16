using HighScoreAPI.Application.DTOs;
using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.Result;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace HighScoreAPI.Application.UseCases;

public class GetPlayerHighScoreByGameUseCase
{
    private readonly IGameRepository _gameRepository;
    private readonly IHighScoreRepository _highscoreRepository;
    private readonly IPlayerRepository _playerRepository;

    public GetPlayerHighScoreByGameUseCase(IGameRepository gameRepository, IPlayerRepository playerRepository, IHighScoreRepository highscoreRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
        _highscoreRepository = highscoreRepository;
    }

    public async Task<OperationResult> Handle(GetPlayerHighScoreByGameRequest request)
    {
        try
        {
            var validationResponse = await ValidationExisting(request);
            if (!validationResponse.Success)
            {
                return validationResponse;
            }

            if (validationResponse.Data is HighScore highScoreResponse)
            {
                var score = new GetScoreDTO
                {
                    Player = highScoreResponse.Player.Username,
                    Game = highScoreResponse.Game.Name,
                    HighScore = highScoreResponse.Score,
                    BreakingScore = highScoreResponse.BreakingScore
                };

                OperationResult result = new OperationResult(200, true, "HighScore returned successfully.");
                result.SetData(score);

                return result;
            }
            else
            {
                return new OperationResult(500, false, "Internal Server Error: Failed to cast validation response data.");
            }
        }
        catch (Exception ex)
        {
            return new OperationResult(500, false, $"Internal Server Error, details: {ex.Message}");
        }
    }

    private async Task<OperationResult> ValidationExisting(GetPlayerHighScoreByGameRequest request)
    {
        var existingGame = await _gameRepository.FindByNameAsync(request.Game, request.Developer);
        if (existingGame == null)
        {
            return new OperationResult(400, false, "Game not exists.");
        }

        var existingPlayer = await _playerRepository.FindByUsernameAsync(request.Player);
        if (existingPlayer == null)
        {
            return new OperationResult(400, false, "Player not exists.");
        }

        var highScoreResponse = await _highscoreRepository.GetHighscoreByPlayerToGameAsync(existingGame.Game_Id, existingPlayer.Id);
        if (highScoreResponse == null)
        {
            return new OperationResult(400, false, "Player has no score in this game.");
        }

        OperationResult result = new OperationResult(200, true, "Validation successfully.");
        result.SetData(highScoreResponse);
        return result;
    }
}