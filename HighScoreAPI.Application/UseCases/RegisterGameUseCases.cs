﻿using HighScoreAPI.Application.DTOs;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;
using HighScoreAPI.Application.Result;
using HighScoreAPI.Domain.Validation.notification;
using System.Reflection.Metadata.Ecma335;

namespace HighScoreAPI.Application.UseCases;
public class RegisterGameUseCases
{
    private readonly IGameRepository _repository;

    public RegisterGameUseCases(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RegisterScorePlayerInGameReques request)
    {
        var game = new Game
        {
            Name = request.Name,
            Type = request.Type,
            Developer = request.Developer
        };

        if (await _repository.ExistsAsync(game))
        {
            return new OperationResult(400, false, "Game already exists.");
        }

        if (game.Validation())
        {
            try
            {
                await _repository.AddAsync(game);

                if (await _repository.ExistsAsync(game))
                {
                    var success = new OperationResult(200, true, "Game registered successfully");
                    success.Data = new GameDTO(game.Game_Id, game.Name, game.Type, game.Developer);
                    return success;
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(500, false, $"Internal Server Error, details: {ex.Message}");
            }
        }

        var result = new OperationResult(400, false, $"Failed to insert the game: {game.Name} into the database, check the fields and try again.");
        result.SetErrors("names are required");
        return result;
    }

}
