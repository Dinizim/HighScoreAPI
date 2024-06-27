using HighScoreAPI.Application.DTOs;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;
using HighScoreAPI.Application.Result;
using HighScoreAPI.Domain.Validation.notification;

namespace HighScoreAPI.Application.UseCases;
public class RegisterGameUseCases
{
    private readonly IGameRepository _repository;

    public RegisterGameUseCases(IGameRepository repository)
    {   
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RegisterGameRequest request)
    {
        var Game = new Game
        {
            Name = request.Name,
            Type = request.Type,
            Developer = request.Developer
        };
        OperationResult result;
        if (Game.Validation())
        {
            try
            {
                _repository.AddAsync(Game);
                return result = new OperationResult(200,true, "Game registered successfully");
        
            }
            catch (Exception ex)
            {
                return result = new OperationResult(500,false, $"Internal Server Error, details: {ex.Message}");
                
            }
        }
       
        result = new OperationResult(400,false, $"Failed to insert the game : {Game.Name} into the database, check the fields and try again. ");
        result.SetErrors("Game and Developer name are required");
        return result;

    }

}
