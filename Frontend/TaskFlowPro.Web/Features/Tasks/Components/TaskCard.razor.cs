using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Components.UI;

namespace TaskFlowPro.Web.Features.Tasks.Components;

public partial class TaskCardBase : ComponentBase
{
    [Parameter] public MockTask Task { get; set; } = null!;
    [Parameter] public int Index { get; set; }
    [Parameter] public bool CanEdit { get; set; }
    [Parameter] public bool IsTeamView { get; set; }
    [Parameter] public MockUser? AssignedUser { get; set; }
    [Parameter] public MockUser? AssignedByUser { get; set; }
    [Parameter] public EventCallback<string> OnEdit { get; set; }
    [Parameter] public EventCallback<string> OnDelete { get; set; }
    [Parameter] public EventCallback<(string Id, string Status)> OnStatusToggle { get; set; }
    
    protected bool IsCompleting { get; set; } = false;
    
    protected async Task HandleStatusToggle(ChangeEventArgs e)
    {
        var isChecked = (bool)(e.Value ?? false);
        var newStatus = isChecked ? "completed" : "pending";
        
        if (newStatus == "completed")
        {
            IsCompleting = true;
            StateHasChanged();
            
            await System.Threading.Tasks.Task.Delay(1000); // Animation duration
            IsCompleting = false;
        }
        
        await OnStatusToggle.InvokeAsync((Task.Id, newStatus));
    }

    protected async Task HandleDelete()
    {
        // In a real app, you'd show a confirmation dialog
        await OnDelete.InvokeAsync(Task.Id);
    }

    protected string GetTaskCardClasses()
    {
        var baseClasses = "p-4 hover:bg-muted/20 transition-all duration-300 hover:scale-[1.02] hover:shadow-md rounded-lg mx-2 my-1 animate-fadeInUp relative overflow-hidden group";
        var completingClasses = IsCompleting ? "animate-checkmark" : "";
        
        return $"{baseClasses} {completingClasses}";
    }

    protected string GetTitleClasses()
    {
        var baseClasses = "font-medium";
        var completedClasses = Task.Status == "completed" ? "line-through text-muted-foreground" : "";
        
        return $"{baseClasses} {completedClasses}";
    }

    protected string GetCheckboxClasses()
    {
        return "w-4 h-4 text-status-completed bg-gray-100 border-gray-300 rounded focus:ring-status-completed focus:ring-2 hover:scale-110 transition-transform duration-200";
    }

    protected Badge.BadgeVariant GetStatusBadgeVariant()
    {
        return Task.Status switch
        {
            "completed" => Badge.BadgeVariant.StatusCompleted,
            "urgent" => Badge.BadgeVariant.StatusUrgent,
            "pending" => Badge.BadgeVariant.StatusPending,
            _ => Badge.BadgeVariant.Default
        };
    }

    protected string GetStatusIcon()
    {
        return Task.Status switch
        {
            "completed" => "fas fa-check-square",
            "urgent" => "fas fa-exclamation-triangle",
            "pending" => "fas fa-clock",
            _ => "fas fa-circle"
        };
    }

    protected string GetStatusBadgeClasses()
    {
        var baseClasses = "hover:scale-105 transition-transform duration-200 shadow-sm hover:shadow-md";
        var pulseClasses = IsCompleting ? "animate-pulse" : "";
        
        return $"{baseClasses} {pulseClasses}";
    }

    protected string GetStatusDisplayName()
    {
        return Task.Status switch
        {
            "completed" => "Completed",
            "urgent" => "Urgent",
            "pending" => "Pending",
            _ => Task.Status
        };
    }

    protected string GetUserInitials(MockUser user)
    {
        return $"{user.FirstName.FirstOrDefault()}{user.LastName.FirstOrDefault()}";
    }

    protected string GetUserDisplayText()
    {
        if (AssignedUser == null) return "";
        
        if (IsTeamView)
        {
            return $"{AssignedUser.FirstName} {AssignedUser.LastName}";
        }
        else if (AssignedByUser != null)
        {
            return $"Assigned by {AssignedByUser.FirstName} {AssignedByUser.LastName}";
        }
        
        return "";
    }

    protected string GetTimeAgo()
    {
        var timeSpan = DateTime.Now - Task.UpdatedAt;
        
        if (timeSpan.TotalDays >= 1)
            return $"{(int)timeSpan.TotalDays}d ago";
        if (timeSpan.TotalHours >= 1)
            return $"{(int)timeSpan.TotalHours}h ago";
        if (timeSpan.TotalMinutes >= 1)
            return $"{(int)timeSpan.TotalMinutes}m ago";
        
        return "Just now";
    }
}
