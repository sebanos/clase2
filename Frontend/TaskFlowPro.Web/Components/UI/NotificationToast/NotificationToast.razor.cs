using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;

namespace TaskFlowPro.Web.Components.UI;

public partial class NotificationToastBase : ComponentBase, IDisposable
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;
    
    protected List<NotificationMessage> Notifications { get; set; } = new();
    private readonly Dictionary<NotificationMessage, Timer> _timers = new();

    protected override void OnInitialized()
    {
        UIState.OnNotification += HandleNotification;
    }

    public void Dispose()
    {
        UIState.OnNotification -= HandleNotification;
        
        // Dispose all timers
        foreach (var timer in _timers.Values)
        {
            timer.Dispose();
        }
        _timers.Clear();
    }

    protected void HandleNotification(NotificationMessage notification)
    {
        Notifications.Add(notification);
        StateHasChanged();
        
        // Auto-remove after duration
        var timer = new Timer(_ =>
        {
            InvokeAsync(() =>
            {
                RemoveNotification(notification);
            });
        }, null, notification.Duration, Timeout.Infinite);
        
        _timers[notification] = timer;
    }

    protected void RemoveNotification(NotificationMessage notification)
    {
        if (Notifications.Contains(notification))
        {
            Notifications.Remove(notification);
            
            if (_timers.TryGetValue(notification, out var timer))
            {
                timer.Dispose();
                _timers.Remove(notification);
            }
            
            StateHasChanged();
        }
    }

    protected string GetNotificationClasses(NotificationType type)
    {
        var baseClasses = "max-w-sm w-full shadow-lg rounded-lg pointer-events-auto ring-1 ring-black ring-opacity-5 overflow-hidden p-4";
        
        var typeClasses = type switch
        {
            NotificationType.Success => "bg-status-completed text-white border-l-4 border-green-300",
            NotificationType.Error => "bg-status-urgent text-white border-l-4 border-red-300",
            NotificationType.Warning => "bg-yellow-500 text-white border-l-4 border-yellow-300",
            NotificationType.Info => "bg-primary text-white border-l-4 border-blue-300",
            _ => "bg-gray-500 text-white border-l-4 border-gray-300"
        };
        
        return $"{baseClasses} {typeClasses}";
    }

    protected string GetNotificationIcon(NotificationType type)
    {
        return type switch
        {
            NotificationType.Success => "fas fa-check-circle",
            NotificationType.Error => "fas fa-exclamation-circle",
            NotificationType.Warning => "fas fa-exclamation-triangle",
            NotificationType.Info => "fas fa-info-circle",
            _ => "fas fa-bell"
        };
    }

    protected string GetIconClasses(NotificationType type)
    {
        return "text-white";
    }
}
