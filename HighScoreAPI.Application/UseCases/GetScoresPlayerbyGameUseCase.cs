using HighScoreAPI.Application.DTOs;
using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.Result;
using HighScoreAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.UseCases;

public class GetScoresPlayerbyGameUseCase
{
    private readonly IGameRepository _gameRepository;
    private readonly IHighScoreRepository _highscoreRepository;

    public GetScoresPlayerbyGameUseCase(IGameRepository gameRepository, IHighScoreRepository highscoreRepository)
    {
        _gameRepository = gameRepository;
        _highscoreRepository = highscoreRepository;
    }

    public async Task<OperationResult> Handle(GetScoresPlayerbyGameRequest request)
    {
        try
        {
            var existingGame = await _gameRepository.FindByNameAsync(request.Game, request.Developer);

            if (existingGame == null)

                return new OperationResult(400, false, "Game not exists.");

            var highScoreResponse = await _highscoreRepository.GetTopHighScoreByGameAsync(existingGame.Game_Id);
            if (highScoreResponse == null)
                return new OperationResult(400, false, "Player has no score in this game.");

            GetScoreDTO[] Scores = highScoreResponse.Select(score => new GetScoreDTO
            {
                Player = score.Player.Username,
                Game = score.Game.Name,
                HighScore = score.Score,
                BreakingScore = score.BreakingScore
            }).ToArray();

            OperationResult result = new OperationResult(200, true, "HighScore returned successfully.");
            result.SetData(highScoreResponse);

            return result;
        }
        catch (Exception ex)
        {
            return new OperationResult(500, false, $"Internal Server Error, details: {ex.Message}");
        }
    }
}