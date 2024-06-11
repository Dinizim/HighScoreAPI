using HighScoreAPI.Domain.Repositories;


namespace HighScoreAPI.Domain.Models;

public class highscore : IModelBase
{
  

    public int Id => HighScoreId;
    public int HighScoreId { get; set; }
    public double Score { get; set; }
    public DateTime BreakingScore { get; set; } = DateTime.UtcNow;

    public int PlayerId { get; set; }
    public Player Player { get; set; }


    public int GameId { get; set; }
    public Game Game { get; set; }

    public bool Validation()
    {
        throw new NotImplementedException();
    }
}

