using TaskFlowPro.Application.DTOs.Common;

namespace TaskFlowPro.Application.DTOs.Tasks;

/// <summary>
/// Task data transfer object for API responses
/// </summary>
public class TaskDto : BaseDto
{
    /// <summary>
    /// Task unique identifier
    /// </summary>
    public int TaskId { get; set; }

    /// <summary>
    /// Task title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Task description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Task status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Task due date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Indicates if the task is overdue
    /// </summary>
    public bool IsOverdue { get; set; }

    /// <summary>
    /// Team information
    /// </summary>
    public TaskTeamDto Team { get; set; } = null!;

    /// <summary>
    /// Assigned user information
    /// </summary>
    public TaskUserDto AssignedTo { get; set; } = null!;

    /// <summary>
    /// Creator user information
    /// </summary>
    public TaskUserDto CreatedBy { get; set; } = null!;
}

/// <summary>
/// Simplified team information for task DTOs
/// </summary>
public class TaskTeamDto
{
    /// <summary>
    /// Team unique identifier
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// Team name
    /// </summary>
    public string TeamName { get; set; } = string.Empty;
}

/// <summary>
/// Simplified user information for task DTOs
/// </summary>
public class TaskUserDto
{
    /// <summary>
    /// User unique identifier
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// User full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// User email
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
