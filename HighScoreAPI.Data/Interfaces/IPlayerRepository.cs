using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Data.Interfaces;

public interface IPlayerRepository : IGenericRepository<Player>
{
}