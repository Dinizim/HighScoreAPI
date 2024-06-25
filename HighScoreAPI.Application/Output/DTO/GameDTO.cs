using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Output.DTO;
public struct GameDTO
{
    public int Id { get; set; }     

    public string Name { get; set; }

    public string Developer { get; set; }
}
