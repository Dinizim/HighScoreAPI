using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Request;

public class RegisterScorePlayerInGameRequest
{
    public string Username { get; set; }

    public string Game { get; set; }

    public string DeveloperGame { get; set; }
    public double Score { get; set; }
}