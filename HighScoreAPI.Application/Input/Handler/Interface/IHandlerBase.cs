using HighScoreAPI.Application.Input.Commands.interfaces;
using HighScoreAPI.Application.Output.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Input.Handler.Interface;
public interface IHandlerBase<in T>
   where T : ICommandBase
{
    IResultBase Handle(T command);
}
