using Microsoft.EntityFrameworkCore.Storage;
using TaskFlowPro.Application.Interfaces;
using TaskFlowPro.Domain.Entities;
using TaskFlowPro.Persistence.Data;
using TaskEntity = TaskFlowPro.Domain.Entities.Task;

namespace TaskFlowPro.Persistence.Repositories;

/// <summary>
/// Unit of Work implementation for managing database transactions
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    // Repository instances
    private IRepository<User>? _users;
    private IRepository<Team>? _teams;
    private IRepository<TaskEntity>? _tasks;
    private IRepository<Role>? _roles;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<User> Users => _users ??= new Repository<User>(_context);
    public IRepository<Team> Teams => _teams ??= new Repository<Team>(_context);
    public IRepository<TaskEntity> Tasks => _tasks ??= new Repository<TaskEntity>(_context);
    public IRepository<Role> Roles => _roles ??= new Repository<Role>(_context);

    public async System.Threading.Tasks.Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async System.Threading.Tasks.Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async System.Threading.Tasks.Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
