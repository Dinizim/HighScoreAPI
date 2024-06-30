using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Application.Request;
public class RegisterGameRequest
{
    public string Name { get; set; }

    public string Type { get; set; }

    public string Developer { get; set; }
}
