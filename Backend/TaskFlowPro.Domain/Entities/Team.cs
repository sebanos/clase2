using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Domain.Entities;

/// <summary>
/// Represents a team in the task management system
/// </summary>
public class Team
{
    /// <summary>
    /// Unique identifier for the team
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// Name of the team
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key to the team leader (User)
    /// </summary>
    public int? LeaderId { get; set; }

    /// <summary>
    /// Timestamp when the team was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the team was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    /// <summary>
    /// Reference to the team leader
    /// </summary>
    public virtual User? Leader { get; set; }

    /// <summary>
    /// Collection of users that belong to this team
    /// </summary>
    public virtual ICollection<User> Members { get; set; } = new List<User>();

    /// <summary>
    /// Collection of tasks assigned to this team
    /// </summary>
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
