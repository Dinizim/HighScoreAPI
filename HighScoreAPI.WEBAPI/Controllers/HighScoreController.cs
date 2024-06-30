using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace HighScoreAPI.WEBAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class HighScoreController : ControllerBase
{
    private readonly RegisterScorePlayerInGameUseCase _registerScorePlayerInGameUseCase;

    public HighScoreController(RegisterScorePlayerInGameUseCase registerScorePlayerInGameUseCase)
    {
        _registerScorePlayerInGameUseCase = registerScorePlayerInGameUseCase;
    }
    [HttpPost("RegisterPlayer")]
    public async Task<IActionResult> RegisterGame([FromBody] RegisterScorePlayerInGameRequest request)
    {
        var result = await _registerScorePlayerInGameUseCase.Handle(request);

        if (!result.Success)
        {
            if (result.StatusCode == 400)
            {
                return BadRequest(result);
            }
            else if (result.StatusCode == 500)
            {
                return StatusCode(500, result);
            }
        }

        return Ok(result);
    }
}