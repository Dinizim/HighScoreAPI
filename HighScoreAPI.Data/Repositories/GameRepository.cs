using HighScoreAPI.Data.Context;
using HighScoreAPI.Domain.Interfaces;
using HighScoreAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HighScoreAPI.Data.Repositories;
public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        try
        {
            return await _context.Games.AsNoTracking().ToArrayAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }
    public async Task<Game> FindByNameAsync(string name , string devoloper)
    {
        try
        {
            var game = await _context.Games.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name && x.Developer == devoloper);
            return game;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }
   

    public async Task<Game> GetByIdAsync(int id)
    {
        try
        {
            var game = await _context.Games.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found"); ;
            }
            return game;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task AddAsync(Game game)
    {
        try
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task UpdateAsync(Game game)
    {
        try
        {
            var existingGame = await _context.Games.FindAsync(game.Id);
            if (existingGame == null)
            {
                throw new KeyNotFoundException($"Entity with id {game.Id} not found");
            }

            _context.Entry(existingGame).CurrentValues.SetValues(game);
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
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found");
            }

            _context.Games.Remove(game);
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
            var GameCount = await _context.Games.LongCountAsync();

            return GameCount;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }

    public async Task<bool> ExistsAsync(Game game)
    {
        bool exists = await _context.Games.AnyAsync(g => g.Name == game.Name && g.Developer == game.Developer);
        return exists;
    }

   
}