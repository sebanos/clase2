using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Application.DTOs.Auth;

/// <summary>
/// DTO for user login
/// </summary>
public class LoginDto
{
    /// <summary>
    /// User email address
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User password
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
