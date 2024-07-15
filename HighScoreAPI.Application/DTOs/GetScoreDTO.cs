using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.DTOs;

public class GetScoreDTO
{
    public string Player { get; set; }
    public string Game { get; set; }
    public double HighScore { get; set; }
    public DateTime BreakingScore { get; set; }
}