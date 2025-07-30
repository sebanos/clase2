namespace TaskFlowPro.Application.DTOs.Common;

/// <summary>
/// Base DTO class with common properties
/// </summary>
public abstract class BaseDto
{
    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
