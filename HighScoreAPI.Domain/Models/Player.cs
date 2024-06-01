using HighScoreAPI.Domain.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HighScoreAPI.Domain.Models;

public class Player : IModelBase
{
    public int Id => Player_Id;
    [Key]
    public int Player_Id { get; set; }
    public string Username { get; set; }
    private string Login { get; set; } = null;
    private string Password { get; set; } = null;

    [JsonIgnore]
    public ICollection<highscore> HighScores { get; set; }
}
