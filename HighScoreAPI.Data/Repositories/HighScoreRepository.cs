using HighScoreAPI.Data.Context;
using HighScoreAPI.Data.Interfaces;
using HighScoreAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
