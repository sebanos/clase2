using TaskFlowPro.Application.DTOs.Users;

namespace TaskFlowPro.Application.DTOs.Auth;

/// <summary>
/// DTO for authentication response
/// </summary>
public class AuthResponseDto
{
    /// <summary>
    /// JWT access token
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Token type (usually "Bearer")
    /// </summary>
    public string TokenType { get; set; } = "Bearer";

    /// <summary>
    /// Token expiration time in seconds
    /// </summary>
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Authenticated user information
    /// </summary>
    public UserDto User { get; set; } = null!;
}
