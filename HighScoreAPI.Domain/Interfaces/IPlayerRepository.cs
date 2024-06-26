using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Domain.Interfaces;

public interface IPlayerRepository : IGenericRepository<Player>
{
}