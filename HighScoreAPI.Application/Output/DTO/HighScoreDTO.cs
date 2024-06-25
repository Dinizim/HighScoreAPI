using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Output.DTO;
    public struct HighScoreDTO
{
    public double Score { get; set; }

    public string Game { get; set; }

    public string Player { get; set; }
}
