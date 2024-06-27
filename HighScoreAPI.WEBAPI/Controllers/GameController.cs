﻿using HighScoreAPI.Application.DTOs;
using HighScoreAPI.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace HighScoreAPI.WEBAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class GameController : ControllerBase
{
    private readonly RegisterGameUseCases _registerGameUseCase;

    public GameController(RegisterGameUseCases registerGameUseCase)
    {
        _registerGameUseCase = registerGameUseCase;
    }
    [HttpPost("RegisterGame")]
    public async Task<IActionResult> RegisterGame([FromBody] RegisterGameRequest request)
    {
        var result = await _registerGameUseCase.Handle(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}

