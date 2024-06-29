using HighScoreAPI.Application.DTOs;
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
    private readonly IPlayerRepository _playerRepository;
    private readonly IHighScoreRepository _highscoreRepository;

    public RegisterScorePlayerInGameUseCase(IGameRepository gamerepository, IPlayerRepository playerRepository, IHighScoreRepository highscoreRepository)
    {
        _gameRepository = gamerepository;
        _playerRepository = playerRepository;
        _highscoreRepository = highscoreRepository;
    }



    public async Task<OperationResult> Handle(RegisterScorePlayerInGameRequest request)
    {
        var game = new Game
        {
            Name = request.Game,
            Developer = request.DeveloperGame
        };
        var player = new Player
        { 
            Username = request.Username
        };
        if(!game.Validation() || !player.Validation()){
            var result = new OperationResult(400, false, $"Failed to insert the new score, check the fields and try again.");
            result.SetErrors("Prop Strings Empty");
            return result;
        }
        if (!await _gameRepository.ExistsAsync(game))
            return new OperationResult(400, false, "Game not exists.");

        if(!await _playerRepository.ExistsAsync(player))
           await  _playerRepository.AddAsync(player);

        var existingGame = await _gameRepository.FindByNameAsync(game.Name);
        var existingPlayer = await _playerRepository.FindByUsernameAsync(player.Username);

        var highscore = new highscore
        { 
            Player = player,
            Game = game,
            Score = request.Score
        };

    }
}
