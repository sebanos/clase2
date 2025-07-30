using Microsoft.AspNetCore.Components;

namespace TaskFlowPro.Web.Components.UI;

public partial class BadgeBase : ComponentBase
{
    [Parameter] public BadgeVariant Variant { get; set; } = BadgeVariant.Default;
    [Parameter] public BadgeSize Size { get; set; } = BadgeSize.Medium;
    [Parameter] public string? Icon { get; set; }
    [Parameter] public bool IsAnimated { get; set; } = true;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] 
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    public enum BadgeVariant 
    { 
        Default, Primary, Secondary, Success, Warning, Danger, Info,
        StatusCompleted, StatusPending, StatusUrgent
    }
    
    public enum BadgeSize 
    { 
        Small, Medium, Large 
    }

    protected string GetBadgeClasses()
    {
        var baseClasses = "inline-flex items-center font-medium rounded-full border transition-all duration-200";
        
        var sizeClasses = Size switch
        {
            BadgeSize.Small => "px-2 py-0.5 text-xs",
            BadgeSize.Large => "px-4 py-1.5 text-sm",
            _ => "px-3 py-1 text-xs"
        };
        
        var variantClasses = Variant switch
        {
            BadgeVariant.Primary => "bg-primary/10 text-primary border-primary/20",
            BadgeVariant.Secondary => "bg-secondary/10 text-secondary border-secondary/20",
            BadgeVariant.Success => "bg-green-100 text-green-800 border-green-200",
            BadgeVariant.Warning => "bg-yellow-100 text-yellow-800 border-yellow-200",
            BadgeVariant.Danger => "bg-red-100 text-red-800 border-red-200",
            BadgeVariant.Info => "bg-blue-100 text-blue-800 border-blue-200",
            BadgeVariant.StatusCompleted => "bg-status-completed/10 text-status-completed border-status-completed/20",
            BadgeVariant.StatusPending => "bg-status-pending/10 text-status-pending border-status-pending/20",
            BadgeVariant.StatusUrgent => "bg-status-urgent/10 text-status-urgent border-status-urgent/20",
            _ => "bg-muted text-muted-foreground border-border"
        };
        
        var animationClasses = IsAnimated ? "hover:scale-105 hover:shadow-md" : "";
        
        return $"{baseClasses} {sizeClasses} {variantClasses} {animationClasses}";
    }

    protected string GetIconClasses()
    {
        return IsAnimated && Variant == BadgeVariant.StatusCompleted ? "animate-pulse" : "";
    }
}
