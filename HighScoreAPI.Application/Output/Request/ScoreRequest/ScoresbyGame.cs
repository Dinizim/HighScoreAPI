using HighScoreAPI.Application.Output.DTO;
using HighScoreAPI.Application.Output.Request.Interfaces;
using HighScoreAPI.Application.Output.Results;

namespace HighScoreAPI.Application.Output.Request.ScoreRequest;

public class ScoresbyGameRequest : IRequestBase
{
    public Result Result { get; set; }
    public GameDTO Game { get; set; }
    public IEnumerable<HighScoreDTO> Scores { get; set; }
}