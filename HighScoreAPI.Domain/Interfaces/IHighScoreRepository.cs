using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Domain.Interfaces;

public interface IHighScoreRepository : IGenericRepository<HighScore>
{
    Task<IEnumerable<HighScore>> GetTopHighScoreByGameAsync(int gameId);

    Task<HighScore> GetHighscoreByPlayerToGameAsync(int gameId, int playerId);
}