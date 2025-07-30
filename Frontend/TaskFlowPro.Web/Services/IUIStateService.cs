namespace TaskFlowPro.Web.Services;

public interface IUIStateService
{
    // Navigation state
    string CurrentView { get; }
    event Action<string>? OnViewChanged;
    void NavigateTo(string view);
    
    // Loading states
    bool IsLoading { get; }
    void SetLoading(bool isLoading);
    
    // User state (mock data)
    MockUser? CurrentUser { get; }
    void SetCurrentUser(MockUser? user);
    void Logout();
    
    // Notifications
    void ShowSuccess(string message);
    void ShowError(string message);
    void ShowInfo(string message);
    
    // Notifications
    event Action<NotificationMessage>? OnNotification;

    // Theme and animations
    bool IsDarkMode { get; }
    void ToggleTheme();

    // Mobile responsiveness
    bool IsMobile { get; }
    event Action<bool>? OnMobileStateChanged;

    // State change notifications
    event Action? OnStateChanged;
}

public class MockUser
{
    public string Id { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public string? TeamId { get; set; }
    public string? TeamName { get; set; }
}

public class NotificationMessage
{
    public NotificationType Type { get; set; }
    public string Message { get; set; } = "";
    public int Duration { get; set; } = 3000;
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

public enum NotificationType
{
    Success,
    Error,
    Info,
    Warning
}
