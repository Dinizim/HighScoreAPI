using HighScoreAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HighScoreAPI.Domain.Models;
public class Game : IModelBase
{
    public int Id => Game_Id;
    [Key]
    public int Game_Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    [JsonIgnore]
    public ICollection<highscore> HighScores { get; set; }
}
