using HighScoreAPI.Application.Request;
using HighScoreAPI.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace HighScoreAPI.WEBAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class HighScoreController : ControllerBase
{
    private readonly RegisterScorePlayerInGameUseCase _registerScorePlayerInGameUseCase;
    private readonly GetPlayerHighScoreByGameUseCase _getPlayerHighScoreByGameUseCase;
    private readonly GetScoresPlayerbyGameUseCase _getTopHighScoreByGameUseCase;


    public HighScoreController(RegisterScorePlayerInGameUseCase registerScorePlayerInGameUseCase, GetPlayerHighScoreByGameUseCase getPlayerHighScoreByGameUse, GetScoresPlayerbyGameUseCase getTopHighScoreByGameUseCase)
    {
        _registerScorePlayerInGameUseCase = registerScorePlayerInGameUseCase;
        _getPlayerHighScoreByGameUseCase = getPlayerHighScoreByGameUse;
        _getTopHighScoreByGameUseCase = getTopHighScoreByGameUseCase;
    }

    [HttpPost("RegisterScore")]
    public async Task<IActionResult> RegisterScore([FromBody] RegisterScorePlayerInGameRequest request)
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

    [HttpGet("GetPlayerHighScore/{game}/{player}/{developer}")]
    public async Task<IActionResult> GetPlayerHighScoreByGame(string game, string player, string developer)
    {
        var request = new GetPlayerHighScoreByGameRequest
        {
            Game = game,
            Player = player,
            Developer = developer
        };
        var result = await _getPlayerHighScoreByGameUseCase.Handle(request);

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





    [HttpGet("GetScores/{gameName}/{developer}")]
    public async Task<IActionResult> GetTopHighScoreByGame(string gameName, string developer)
    {
        var request = new GetScoresPlayerbyGameRequest
        {
            Game = gameName,
            Developer = developer
        };
        {
            var result = await _getTopHighScoreByGameUseCase.Handle(request);

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
}