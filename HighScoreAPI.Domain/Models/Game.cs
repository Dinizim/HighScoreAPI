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
    public DateTime CreatedAt { get;} =  DateTime.UtcNow;
    public string Developer { get; set; }


    [JsonIgnore]
    public ICollection<highscore> HighScores { get; set; }

    public override bool Validation()
    {
        var contract = new ContractValidations<Game>()
            .NameNotEmptyOK(this.Name, 20 , "Invalid Name. Please enter a shorter name", "Name")
            .NameNotEmptyOK(this.Developer, 20, "Invalid Name. Please enter a shorter name", "Developer");

        return contract.IsValid();
    }
}
