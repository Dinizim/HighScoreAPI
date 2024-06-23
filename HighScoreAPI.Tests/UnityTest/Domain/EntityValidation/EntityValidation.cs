using HighScoreAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Tests.UnityTest.Domain.EntityValidation;
public class EntityValidation
{
    [Fact(DisplayName = "Player Name Validation")]
    public void GivenPlayerInvalidName_When_Emptyorlarge_ShouldFail()
    {
        var player = new Player { Username = "" };

        Assert.False(player.Validation());

        player.Username = "123456789010111213141516171819120";

        Assert.False(player.Validation());
    }

    [Fact(DisplayName = "Game Name Validation")]
    public void GivenGameInvalidName_When_Emptyorlarge_ShouldFail()
    {
        var game = new Game { Name = "", Developer = "" };

        Assert.False(game.Validation());

        game.Name = "123456789010111213141516171819120";
        game.Developer = "DnDeveloper";

        Assert.False(game.Validation());

    }

    [Fact(DisplayName = "Score Validation")]
    public void GivenNegativeScore_When_NegativeNumber_ShouldFail()
    {
        var HighScore = new highscore { Score = -10 };

        Assert.False(HighScore.Validation());

    }
}
