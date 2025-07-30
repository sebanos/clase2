using TaskFlowPro.Domain.Entities;
using TaskEntity = TaskFlowPro.Domain.Entities.Task;

namespace TaskFlowPro.Application.Interfaces;

/// <summary>
/// Unit of Work pattern interface for managing database transactions
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Repository for User entities
    /// </summary>
    IRepository<User> Users { get; }

    /// <summary>
    /// Repository for Team entities
    /// </summary>
    IRepository<Team> Teams { get; }

    /// <summary>
    /// Repository for Task entities
    /// </summary>
    IRepository<TaskEntity> Tasks { get; }

    /// <summary>
    /// Repository for Role entities
    /// </summary>
    IRepository<Role> Roles { get; }

    /// <summary>
    /// Saves all changes made in this unit of work to the database
    /// </summary>
    /// <returns>Number of affected rows</returns>
    System.Threading.Tasks.Task<int> SaveChangesAsync();

    /// <summary>
    /// Begins a new database transaction
    /// </summary>
    System.Threading.Tasks.Task BeginTransactionAsync();

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    System.Threading.Tasks.Task CommitTransactionAsync();

    /// <summary>
    /// Rolls back the current transaction
    /// </summary>
    System.Threading.Tasks.Task RollbackTransactionAsync();
}
