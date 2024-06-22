using HighScoreAPI.Domain.Repositories;
using HighScoreAPI.Domain.Validation;
using HighScoreAPI.Domain.Validation.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HighScoreAPI.Domain.Models;

public class Player : BaseEntity, IContract
{
    public int Id => Player_Id;

    [Key]
    public int Player_Id { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public ICollection<highscore> HighScores { get; set; }

    public override bool Validation()
    {
        var contract = new ContractValidations<Player>()
            .NameNotEmptyOK(this.Username, 20, "The name exceeds the maximum allowed length. Please enter a shorter name", "Name");

        return contract.IsValid();
    }
}