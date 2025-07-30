namespace TaskFlowPro.Domain.Enums;

/// <summary>
/// Enumeration of possible task statuses
/// </summary>
public enum TaskStatus
{
    /// <summary>
    /// Task is pending and not yet started
    /// </summary>
    Pending,

    /// <summary>
    /// Task is currently being worked on
    /// </summary>
    InProgress,

    /// <summary>
    /// Task has been completed
    /// </summary>
    Completed,

    /// <summary>
    /// Task is overdue (past due date and not completed)
    /// </summary>
    Overdue,

    /// <summary>
    /// Task has been cancelled
    /// </summary>
    Cancelled
}
