


Este documento descreve a implementação e o uso de vários repositórios no projeto `HighScoreAPI`. Esses repositórios são usados para gerenciar entidades como Jogadores, Jogos e Pontuações Altas em um banco de dados utilizando Entity Framework Core. Cada repositório segue um padrão genérico definido pela interface `IGenericRepository`.



Os repositórios devem atender aos seguintes requisitos:
- [x] Implementar operações CRUD (Create, Read, Update, Delete) para as entidades.
- [x] Suportar operações assíncronas para melhor desempenho.
- [x] Garantir que as exceções sejam tratadas adequadamente.
- [x] Verificar a existência de entidades pelo seu ID.



### Interface Genérica de Repositório

A interface `IGenericRepository` define um contrato para operações básicas em um repositório. Este contrato deve ser implementado por repositórios que gerenciam entidades específicas.

```csharp
namespace HighScoreAPI.Domain.Repositories
{
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
}
```
### Explicação das Operações

- **GetByIdAsync(int id):**
  Obtém uma entidade pelo seu ID. Esta operação é assíncrona e retorna a entidade correspondente ao ID fornecido ou nula se a entidade não for encontrada.

- **GetAllAsync():**
  Obtém todas as entidades do repositório. Esta operação é assíncrona e retorna uma coleção de todas as entidades.

- **AddAsync(T entity):**
  Adiciona uma nova entidade ao repositório. Esta operação é assíncrona e persiste a nova entidade no banco de dados.

- **UpdateAsync(T entity):**
  Atualiza uma entidade existente no repositório. Esta operação é assíncrona e aplica as mudanças na entidade fornecida ao banco de dados.

- **DeleteAsync(int id):**
  Exclui uma entidade pelo seu ID. Esta operação é assíncrona e remove a entidade correspondente ao ID fornecido do banco de dados.

- **CountAsync():**
  Conta o número total de entidades no repositório. Esta operação é assíncrona e retorna o número de entidades presentes.

- **ExistsAsync(int id):**
  Verifica se uma entidade existe pelo seu ID. Esta operação é assíncrona e retorna verdadeiro se a entidade com o ID fornecido existir, caso contrário, retorna falso.

<hr>

### Exemplo de Implementação: IHighScoreRepository

O repositório `IHighScoreRepository` estende a interface genérica para a entidade `HighScore`, adicionando métodos específicos para pontuações altas.

```csharp
public interface IHighScoreRepository : IGenericRepository<HighScore>
{
    Task<IEnumerable<HighScore>> GetTopHighScoreByGameAsync(int gameId);

    Task<HighScore> GetHighscoreByPlayerToGameAsync(int gameId, int playerId);
}
```


### Propósito do `IHighScoreRepository`

Gerenciar operações relacionadas às pontuações altas no contexto do jogo.

<hr>

### Implementação Concreta: `HighScoreRepository`

Aqui está a implementação concreta do `IHighScoreRepository`, utilizando Entity Framework Core para acesso aos dados:

```csharp
public class HighScoreRepository : IHighScoreRepository
{
    private readonly AppDbContext _context;

    public HighScoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HighScore>> GetTopHighScoreByGameAsync(int gameId)
    {
        try
        {
            return await _context.HighScores
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

    public async Task<HighScore> GetHighscoreByPlayerToGameAsync(int gameId, int playerId)
    {
        try
        {
            return await _context.HighScores
                .OrderByDescending(x => x.Score)
                .FirstOrDefaultAsync(x => x.GameId == gameId && x.PlayerId == playerId);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while accessing the database", ex);
        }
    }
}
```
### Propósito da `Implementação`

Gerenciar consultas e modificações nas pontuações altas dos jogadores em diferentes jogos.
