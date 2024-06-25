using HighScoreAPI.Application.Output.DTO;
using HighScoreAPI.Application.Output.Request.Interfaces;
using HighScoreAPI.Application.Output.Results;

namespace HighScoreAPI.Application.Output.Request.ScoreRequest;

public class ScoreByPlayerRequest : IRequestBase
{
    public Result Result { get; set; }

    public HighScoreDTO Score { get; set; }
}