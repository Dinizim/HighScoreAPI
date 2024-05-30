using HighScoreAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Domain.Models;

public class highscore : IModelBase
{
    public int Id => HighScoreId;
    public int HighScoreId { get; set; }
    public double Score { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }


    public int GameId { get; set; }
    public Game Game { get; set; }
}

