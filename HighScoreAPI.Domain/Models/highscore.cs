using HighScoreAPI.Domain.Repositories;
using HighScoreAPI.Domain.Validation;
using HighScoreAPI.Domain.Validation.Interfaces;


namespace HighScoreAPI.Domain.Models;

public class highscore : BaseEntity , IContract
{
  

    public int Id => HighScoreId;
    public int HighScoreId { get; set; }
    public double Score { get; set; }
    public DateTime BreakingScore { get;} = DateTime.UtcNow;

    public int PlayerId { get; private set; }
    public Player Player { get; private set; }


    public int GameId { get; set; }
    public Game Game { get; set; }

    public override bool Validation()
    {
        var contract = new ContractValidations<highscore>()
            .ScoreNoTNegativeOK(Score, "The score cannot be negative. Please Enter a valid score", "Score");

        return contract.IsValid();
    }
}

