using HighScoreAPI.Data.Context;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HighScoreAPI.Data.Repositories;

public class HighScoreRepository : IHighScoreRepository
{
    private readonly AppDbContext _context;

    public HighScoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<highscore>> GetAllAsync()
    {
        try
        {
            return await _context
                .HighScores
                .AsNoTracking()
                .Include(x => x.Player)
                .Include(x => x.Game)
                .ToArrayAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task<highscore> GetByIdAsync(int id)
    {
        try
        {
            var highscore = await _context
                .HighScores
                .AsNoTracking()
                .Include(x => x.Player)
                .Include(x => x.Game)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (highscore == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found");
            }
            return highscore;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task AddAsync(highscore highscore)
    {
        try
        {
            await _context.HighScores.AddAsync(highscore);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task UpdateAsync(highscore highscore)
    {
        try
        {
            var existingHighscore = await _context.HighScores.FindAsync(highscore.Id);
            if (existingHighscore == null)
            {
                throw new KeyNotFoundException($"Entity with id {highscore.Id} not found");
            }

            _context.Entry(existingHighscore).CurrentValues.SetValues(highscore);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var highscore = await _context.HighScores.FindAsync(id);
            if (highscore == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found");
            }

            _context.HighScores.Remove(highscore);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task<long> CountAsync()
    {
        try
        {
            var ScoreCount = await _context.HighScores.LongCountAsync();

            return ScoreCount;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var highscore = await _context.HighScores.FindAsync(id);
        if (highscore == null)
        {
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<highscore>> GetTopHighScoreByGameAsync(int gameId)
    {
        try
        {
            return await _context
                .HighScores
                .OrderByDescending(x => x.Score)
                .Where(x => x.GameId == gameId)
                .Take(20)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task<highscore> GetHighscoreByPlayerToGameAsync(int gameId, int playerId)
    {
        try
        {
            return await _context
                .HighScores
                .OrderByDescending(x => x.Score)
                .Where(x => x.GameId == gameId && x.PlayerId == playerId)
                .FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }
}