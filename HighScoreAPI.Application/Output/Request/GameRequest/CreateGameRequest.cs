using HighScoreAPI.Application.Output.DTO;
using HighScoreAPI.Application.Output.Request.Interfaces;
using HighScoreAPI.Application.Output.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Output.Request.GameRequest;
public class CreateGameRequest : IRequestBase
{
    public Result Result { get; set; }

    public GameDTO Game { get; set; }
}
