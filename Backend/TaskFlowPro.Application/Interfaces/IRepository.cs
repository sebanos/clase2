using System.Linq.Expressions;

namespace TaskFlowPro.Application.Interfaces;

/// <summary>
/// Generic repository interface for data access operations
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Gets all entities
    /// </summary>
    /// <returns>Collection of all entities</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Gets entities based on a predicate
    /// </summary>
    /// <param name="predicate">Filter condition</param>
    /// <returns>Filtered collection of entities</returns>
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Gets a single entity by its identifier
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <returns>Entity if found, null otherwise</returns>
    Task<T?> GetByIdAsync(object id);

    /// <summary>
    /// Gets a single entity based on a predicate
    /// </summary>
    /// <param name="predicate">Filter condition</param>
    /// <returns>First entity matching the condition, null if not found</returns>
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Adds a new entity
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <returns>Added entity</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Adds multiple entities
    /// </summary>
    /// <param name="entities">Entities to add</param>
    Task AddRangeAsync(IEnumerable<T> entities);

    /// <summary>
    /// Updates an existing entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    void Update(T entity);

    /// <summary>
    /// Updates multiple entities
    /// </summary>
    /// <param name="entities">Entities to update</param>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Removes an entity
    /// </summary>
    /// <param name="entity">Entity to remove</param>
    void Remove(T entity);

    /// <summary>
    /// Removes multiple entities
    /// </summary>
    /// <param name="entities">Entities to remove</param>
    void RemoveRange(IEnumerable<T> entities);

    /// <summary>
    /// Checks if any entity matches the predicate
    /// </summary>
    /// <param name="predicate">Filter condition</param>
    /// <returns>True if any entity matches, false otherwise</returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Counts entities matching the predicate
    /// </summary>
    /// <param name="predicate">Filter condition</param>
    /// <returns>Number of entities matching the condition</returns>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
}
