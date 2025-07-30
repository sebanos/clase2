using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Application.DTOs.Tasks;

/// <summary>
/// DTO for creating a new task
/// </summary>
public class CreateTaskDto
{
    /// <summary>
    /// Task title
    /// </summary>
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(255, ErrorMessage = "Title cannot exceed 255 characters")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Task description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Team ID where the task belongs
    /// </summary>
    [Required(ErrorMessage = "Team ID is required")]
    public int TeamId { get; set; }

    /// <summary>
    /// User ID to assign the task to
    /// </summary>
    [Required(ErrorMessage = "Assigned user ID is required")]
    public int AssignedToUserId { get; set; }

    /// <summary>
    /// Task due date (optional)
    /// </summary>
    public DateTime? DueDate { get; set; }
}
