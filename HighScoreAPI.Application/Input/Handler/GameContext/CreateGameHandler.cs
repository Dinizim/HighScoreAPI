using HighScoreAPI.Application.Input.Commands.GameContext;
using HighScoreAPI.Application.Input.Handler.Interface;
using HighScoreAPI.Application.Output.Results;
using HighScoreAPI.Application.Output.Results.Interfaces;
using HighScoreAPI.Application.Repositories.Interfaces;
using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Validation.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Input.Handler.GameContext;
public class CreateGameHandler : IHandlerBase<CreateGameCommand>
{
    private readonly IGameRepository _repository;
    public CreateGameHandler(IGameRepository repository)
    {
        _repository = repository;
    }


    public IResultBase Handle(CreateGameCommand command)
    {
        var Game = new Game { Name = command.Name , Developer = command.Developer , Type = command.Type};
        Result result;
        if (Game.Validation())
        {
            try
            {
                _repository.AddAsync(Game);
                result = new Result(200, $"game : {Game.Name} created successfully", true);
                result.SetData(Game);
                return result;
            }
            catch (Exception ex)
            {
                result = new Result(500, $"Internal Server Error, details: {ex.Message}", false);
                return result;
            }
        }
        result = new Result(400, $"Failed to insert the game : {Game.Name} into the database, check the fields and try again. ", false);
        result.SetNotifications(Game.Notifications as List<Notification>);
        return result;
    }
    }
}
