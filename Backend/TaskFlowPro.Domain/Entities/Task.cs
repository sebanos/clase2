using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Domain.Entities;

/// <summary>
/// Represents a task in the task management system
/// </summary>
public class Task
{
    /// <summary>
    /// Unique identifier for the task
    /// </summary>
    public int TaskId { get; set; }

    /// <summary>
    /// Title of the task
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of the task
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Current status of the task
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Pending";

    /// <summary>
    /// Foreign key to the team this task belongs to
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// Foreign key to the user assigned to this task
    /// </summary>
    public int AssignedToUserId { get; set; }

    /// <summary>
    /// Foreign key to the user who created this task
    /// </summary>
    public int CreatedByUserId { get; set; }

    /// <summary>
    /// Timestamp when the task was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the task was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Due date for the task (optional)
    /// </summary>
    public DateTime? DueDate { get; set; }

    // Navigation properties
    /// <summary>
    /// Reference to the team this task belongs to
    /// </summary>
    public virtual Team Team { get; set; } = null!;

    /// <summary>
    /// Reference to the user assigned to this task
    /// </summary>
    public virtual User AssignedToUser { get; set; } = null!;

    /// <summary>
    /// Reference to the user who created this task
    /// </summary>
    public virtual User CreatedByUser { get; set; } = null!;

    /// <summary>
    /// Computed property to check if task is overdue
    /// </summary>
    public bool IsOverdue => DueDate.HasValue && DueDate.Value < DateTime.UtcNow && Status != "Completed" && Status != "Cancelled";
}
