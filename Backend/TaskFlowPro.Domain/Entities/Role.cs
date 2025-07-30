using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Domain.Entities;

/// <summary>
/// Represents a system role for role-based access control
/// </summary>
public class Role
{
    /// <summary>
    /// Unique identifier for the role
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Name of the role (e.g., "Global Administrator", "Team Leader", "Team Member", "User without Team")
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string RoleName { get; set; } = string.Empty;

    // Navigation properties
    /// <summary>
    /// Collection of users assigned to this role
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
