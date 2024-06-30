using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace HighScoreAPI.WEBAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class GameController : ControllerBase
{
    private readonly RegisterGameUseCase _registerGameUseCase;

    public GameController(RegisterGameUseCase registerGameUseCase)
    {
        _registerGameUseCase = registerGameUseCase;
    }
    
    [HttpPost("RegisterGame")]
    public async Task<IActionResult> RegisterGame([FromBody] RegisterGameRequest request)
    {
        var result = await _registerGameUseCase.Handle(request);

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

