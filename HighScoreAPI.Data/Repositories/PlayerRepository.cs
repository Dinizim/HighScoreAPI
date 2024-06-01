﻿using HighScoreAPI.Data.Context;
using HighScoreAPI.Data.Interfaces;
using HighScoreAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScoreAPI.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
   

        public PlayerRepository(AppDbContext context, ILogger<PlayerRepository> logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            try
            {
                return await _context.Players.AsNoTracking().ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while accessing the database", ex);
            }
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            try
            {
                var player = await _context.Players.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (player == null)
                {
                    
                    throw new KeyNotFoundException($"Player with id {id} not found");
                }
                return player;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while accessing the database", ex);
            }
        }

        public async Task AddAsync(Player player)
        {
            try
            {
                await _context.Players.AddAsync(player);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while accessing the database", ex);
            }
        }

        public async Task UpdateAsync(Player player)
        {
            try
            {
                var existingPlayer = await _context.Players.FindAsync(player.Id);
                if (existingPlayer == null)
                {

                    throw new KeyNotFoundException($"Player with id {player.Id} not found");
                }

                _context.Entry(existingPlayer).CurrentValues.SetValues(player);
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
                var player = await _context.Players.FindAsync(id);
                if (player == null)
                {
                    throw new KeyNotFoundException($"Player with id {id} not found");
                }

                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while accessing the database", ex);
            }
        }
    }
}
