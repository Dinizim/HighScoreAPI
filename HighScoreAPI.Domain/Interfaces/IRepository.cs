namespace HighScoreAPI.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(int id);

    Task<long> CountAsync();

    Task<bool> ExistsAsync(int id);
}