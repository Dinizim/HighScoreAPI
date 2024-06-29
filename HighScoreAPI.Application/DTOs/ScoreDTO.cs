using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.DTOs;
public  class ScoreDTO
{
    public ScoreDTO(string username, string game, string developerGame, double score)
    {
        Username = username;
        Game = game;
        DeveloperGame = developerGame;
        Score = score;
    }

    public string Username { get; set; }

    public string Game { get; set; }

    public string DeveloperGame { get; set; }

    public double Score { get; set; }

    public DateTime BreakingScore { get; } = DateTime.UtcNow;

}
