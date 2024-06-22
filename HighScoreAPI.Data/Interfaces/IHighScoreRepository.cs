using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreAPI.Data.Interfaces;
public interface IHighScoreRepository : IGenericRepository<highscore>
{
    Task<IEnumerable<highscore>> GetTopHighScoreByGameAsync(int gameId);
    Task<highscore> GetHighscoreByPlayerToGameAsync(int gameId, int playerId);
}
