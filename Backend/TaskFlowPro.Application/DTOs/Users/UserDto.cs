using TaskFlowPro.Application.DTOs.Common;

namespace TaskFlowPro.Application.DTOs.Users;

/// <summary>
/// User data transfer object for API responses
/// </summary>
public class UserDto : BaseDto
{
    /// <summary>
    /// User unique identifier
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// User email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// User last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// User full name (computed)
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// User role name
    /// </summary>
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// Team information (if assigned)
    /// </summary>
    public UserTeamDto? Team { get; set; }
}

/// <summary>
/// Simplified team information for user DTOs
/// </summary>
public class UserTeamDto
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
    /// Indicates if the user is the team leader
    /// </summary>
    public bool IsTeamLeader { get; set; }
}
