﻿using HighScoreAPI.Domain.Models;
using HighScoreAPI.Domain.Repositories;

namespace HighScoreAPI.Domain.Interfaces;

public interface IGameRepository : IGenericRepository<Game>
{
    Task<Game> FindByNameAsync(string name,string developer);
}