using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Application.Repositories.Interfaces;

public interface IGameRepository : IGenericRepository<Game>
{
}