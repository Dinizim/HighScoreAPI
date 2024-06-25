using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Data.Interfaces;

public interface IGameRepository : IGenericRepository<Game>
{
}