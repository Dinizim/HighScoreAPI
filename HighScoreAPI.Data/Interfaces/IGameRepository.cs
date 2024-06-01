using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Data.Interfaces;
public interface IGameRepository : IGenericRepository<Game>
{
}
