using HighScoreAPI.Application.Input.Commands.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HighScoreAPI.Application.Input.Commands.GameContext;
public class CreateGameCommand : ICommandBase
{
    public string Name { get; set; }

    public string Type { get; set; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public string Developer { get; set; }
}
