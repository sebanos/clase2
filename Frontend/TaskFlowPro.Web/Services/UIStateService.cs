namespace TaskFlowPro.Web.Services;

public class UIStateService : IUIStateService
{
    private string _currentView = "my-tasks";
    private bool _isLoading = false;
    private bool _isDarkMode = false;
    private bool _isMobile = false;
    private MockUser? _currentUser;
    
    public string CurrentView => _currentView;
    public bool IsLoading => _isLoading;
    public bool IsDarkMode => _isDarkMode;
    public bool IsMobile => _isMobile;
    public MockUser? CurrentUser => _currentUser;
    
    public event Action<string>? OnViewChanged;
    public event Action<bool>? OnMobileStateChanged;
    public event Action<NotificationMessage>? OnNotification;
    public event Action? OnStateChanged;
    
    public void NavigateTo(string view)
    {
        _currentView = view;
        OnViewChanged?.Invoke(view);
        OnStateChanged?.Invoke();
    }
    
    public void SetLoading(bool isLoading)
    {
        _isLoading = isLoading;
        OnStateChanged?.Invoke();
    }
    
    public void SetCurrentUser(MockUser? user)
    {
        _currentUser = user;
        OnStateChanged?.Invoke();
    }
    
    public void Logout()
    {
        _currentUser = null;
        _currentView = "login";
        OnStateChanged?.Invoke();
    }
    
    public void ShowSuccess(string message)
    {
        OnNotification?.Invoke(new NotificationMessage
        {
            Type = NotificationType.Success,
            Message = message,
            Duration = 3000
        });
    }
    
    public void ShowError(string message)
    {
        OnNotification?.Invoke(new NotificationMessage
        {
            Type = NotificationType.Error,
            Message = message,
            Duration = 5000
        });
    }
    
    public void ShowInfo(string message)
    {
        OnNotification?.Invoke(new NotificationMessage
        {
            Type = NotificationType.Info,
            Message = message,
            Duration = 3000
        });
    }
    
    public void ToggleTheme()
    {
        _isDarkMode = !_isDarkMode;
        OnStateChanged?.Invoke();
    }
    
    // Mock data for demo
    public void InitializeMockData()
    {
        // This would normally come from authentication service
        _currentUser = new MockUser
        {
            Id = "1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@taskflow.com",
            Role = "team_leader",
            TeamId = "team1",
            TeamName = "Development Team"
        };
    }
}
