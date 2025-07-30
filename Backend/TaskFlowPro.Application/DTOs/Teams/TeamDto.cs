using TaskFlowPro.Application.DTOs.Common;

namespace TaskFlowPro.Application.DTOs.Teams;

/// <summary>
/// Team data transfer object for API responses
/// </summary>
public class TeamDto : BaseDto
{
    /// <summary>
    /// Team unique identifier
    /// </summary>
    public int TeamId { get; set; }

    /// <summary>
    /// Team name
    /// </summary>
    public string TeamName { get; set; } = string.Empty;

    /// <summary>
    /// Team leader information
    /// </summary>
    public TeamLeaderDto? Leader { get; set; }

    /// <summary>
    /// Number of team members
    /// </summary>
    public int MemberCount { get; set; }

    /// <summary>
    /// Number of active tasks
    /// </summary>
    public int ActiveTaskCount { get; set; }
}

/// <summary>
/// Simplified leader information for team DTOs
/// </summary>
public class TeamLeaderDto
{
    /// <summary>
    /// Leader user ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Leader full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Leader email
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
