using HighScoreAPI.Domain.Validation;
using HighScoreAPI.Domain.Validation.Interfaces;

namespace HighScoreAPI.Domain.Models;

public class HighScore : BaseEntity, IContract
{
    public int Id => HighScoreId;
    public int HighScoreId { get; set; }
    public double Score { get; set; }
    public DateTime BreakingScore { get; } = DateTime.UtcNow;

    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }

    public override bool Validation()
    {
        var contract = new ContractValidations<HighScore>()
            .ScoreNoTNegativeOK(Score, "The score cannot be negative. Please Enter a valid score", "Score");

        return contract.IsValid();
    }
}