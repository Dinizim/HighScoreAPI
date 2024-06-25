using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Data.Interfaces;

public interface IHighScoreRepository : IGenericRepository<highscore>
{
    Task<IEnumerable<highscore>> GetTopHighScoreByGameAsync(int gameId);

    Task<highscore> GetHighscoreByPlayerToGameAsync(int gameId, int playerId);
}