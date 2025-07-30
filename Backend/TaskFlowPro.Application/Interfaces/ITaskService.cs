using TaskFlowPro.Domain.Entities;
using TaskEntity = TaskFlowPro.Domain.Entities.Task;

namespace TaskFlowPro.Application.Interfaces;

/// <summary>
/// Service interface for task-related operations
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Gets all tasks
    /// </summary>
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();

    /// <summary>
    /// Gets a task by its ID
    /// </summary>
    /// <param name="taskId">Task identifier</param>
    Task<TaskEntity?> GetTaskByIdAsync(int taskId);

    /// <summary>
    /// Gets tasks assigned to a specific user
    /// </summary>
    /// <param name="userId">User identifier</param>
    Task<IEnumerable<TaskEntity>> GetTasksByUserAsync(int userId);

    /// <summary>
    /// Gets tasks belonging to a specific team
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<IEnumerable<TaskEntity>> GetTasksByTeamAsync(int teamId);

    /// <summary>
    /// Gets tasks with a specific status
    /// </summary>
    /// <param name="status">Task status</param>
    Task<IEnumerable<TaskEntity>> GetTasksByStatusAsync(string status);

    /// <summary>
    /// Gets overdue tasks
    /// </summary>
    Task<IEnumerable<TaskEntity>> GetOverdueTasksAsync();

    /// <summary>
    /// Gets tasks created by a specific user
    /// </summary>
    /// <param name="userId">User identifier</param>
    Task<IEnumerable<TaskEntity>> GetTasksCreatedByUserAsync(int userId);

    /// <summary>
    /// Creates a new task
    /// </summary>
    /// <param name="task">Task to create</param>
    Task<TaskEntity> CreateTaskAsync(TaskEntity task);

    /// <summary>
    /// Updates an existing task
    /// </summary>
    /// <param name="task">Task to update</param>
    Task<TaskEntity> UpdateTaskAsync(TaskEntity task);

    /// <summary>
    /// Deletes a task
    /// </summary>
    /// <param name="taskId">Task identifier</param>
    Task<bool> DeleteTaskAsync(int taskId);

    /// <summary>
    /// Assigns a task to a user
    /// </summary>
    /// <param name="taskId">Task identifier</param>
    /// <param name="userId">User identifier</param>
    Task<bool> AssignTaskToUserAsync(int taskId, int userId);

    /// <summary>
    /// Updates the status of a task
    /// </summary>
    /// <param name="taskId">Task identifier</param>
    /// <param name="status">New status</param>
    Task<bool> UpdateTaskStatusAsync(int taskId, string status);

    /// <summary>
    /// Sets or updates the due date of a task
    /// </summary>
    /// <param name="taskId">Task identifier</param>
    /// <param name="dueDate">Due date</param>
    Task<bool> SetTaskDueDateAsync(int taskId, DateTime? dueDate);
}
