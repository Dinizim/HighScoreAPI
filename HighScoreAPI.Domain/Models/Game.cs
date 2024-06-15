using HighScoreAPI.Domain.Repositories;
using HighScoreAPI.Domain.Validation;
using HighScoreAPI.Domain.Validation.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HighScoreAPI.Domain.Models;
public class Game : BaseEntity, IContract
{
    public int Id => Game_Id;
    [Key]
    public int Game_Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    [JsonIgnore]
    public ICollection<highscore> HighScores { get; set; }

    public override bool Validation()
    {
        var contract = new ContractValidations<Game>()
            .NameIsUniqueOK(this.Name, 20, "The name must be unique. Please enter a different name", "Name")
            .NameNotEmptyOK(this.Name, 20 , "The name exceeds the maximum allowed length. Please enter a shorter name", "Name");

        return contract.IsValid();
    }
}
