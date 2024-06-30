using HighScoreAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Request;
public class GetPlayerHighScoreByGameRequest
{
    public string Game { get; set; }

    public string Player { get; set; }

    public string Developer { get; set; }

    public double Score { get; set; }


}
