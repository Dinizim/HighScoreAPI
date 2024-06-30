using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.Result;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;


namespace HighScoreAPI.Application.UseCases;
public class GetPlayerHighScoreByGameUseCase
{
    private readonly IGameRepository _gameRepository;
    private readonly IHighScoreRepository _highscoreRepository;
    private readonly IPlayerRepository _playerRepository;


    public GetPlayerHighScoreByGameUseCase(IGameRepository gamerepository, IPlayerRepository playerRepository, IHighScoreRepository repository)
    {
        _gameRepository = gamerepository;
        _playerRepository = playerRepository;
        _highscoreRepository = repository;
    }

    public async Task<OperationResult> Handle(GetPlayerHighScoreByGameRequest request)
    {
        try
        {
            var existingGame = await _gameRepository.FindByNameAsync(request.Game, request.Developer);

            if (existingGame == null)
                return new OperationResult(400, false, "Game not exists.");

            var existingPlayer = await _playerRepository.FindByUsernameAsync(request.Player);
            if (existingPlayer == null)
                return new OperationResult(400, false, "Player not exists.");

            var highScoreResponse = await _highscoreRepository.GetHighscoreByPlayerToGameAsync(existingGame.Game_Id, existingPlayer.Id);

            if (highScoreResponse == null)
                return new OperationResult(400, false, "Player has no score in this game.");

            OperationResult result = new OperationResult(200, true, "HighScore returned successfully.");
            result.Data = highScoreResponse;

            return result;

        }catch(Exception ex)
        {
            return new OperationResult(500, false, $"Internal Server Error, details: {ex.Message}");
        }
    }

}
