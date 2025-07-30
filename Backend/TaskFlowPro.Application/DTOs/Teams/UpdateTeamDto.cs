using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Application.DTOs.Teams;

/// <summary>
/// DTO for updating an existing team
/// </summary>
public class UpdateTeamDto
{
    /// <summary>
    /// Team name
    /// </summary>
    [Required(ErrorMessage = "Team name is required")]
    [MaxLength(100, ErrorMessage = "Team name cannot exceed 100 characters")]
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Leader user ID (optional)
    /// </summary>
    public int? LeaderId { get; set; }
}
