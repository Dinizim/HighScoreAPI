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
public class PlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _context;
    public PlayerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await _context
            .Players
            .AsNoTracking()
            .ToArrayAsync();
    }
    public async Task<Player> GetByIdAsync(int id)
    {
        return await _context
            .Players
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task AddAsync(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Player player)
    {
        var existingPlayer = await _context.Players.FindAsync(player.Id);
        if (existingPlayer != null)
        {
            _context.Entry(existingPlayer).CurrentValues.SetValues(player);
            await _context.SaveChangesAsync();
        }
       
    }
    public async Task DeleteAsync(int id)
    {
        var player = await _context.Players.FindAsync(id);

       if (player != null) {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}
