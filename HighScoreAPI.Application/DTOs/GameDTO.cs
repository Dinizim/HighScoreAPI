using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.DTOs;
public class GameDTO
{
    public GameDTO(int id, string name, string type, string developer)
    {
        Id = id;
        Name = name;
        Type = type;
        Developer = developer;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Developer { get; set; }
}
