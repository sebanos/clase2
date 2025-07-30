using Microsoft.AspNetCore.Components;

namespace TaskFlowPro.Web.Components.UI;

public partial class AvatarBase : ComponentBase
{
    [Parameter] public string? ImageUrl { get; set; }
    [Parameter] public string? Initials { get; set; }
    [Parameter] public string? AltText { get; set; }
    [Parameter] public AvatarSize Size { get; set; } = AvatarSize.Medium;
    [Parameter] public bool ShowOnlineIndicator { get; set; }
    [Parameter] public bool IsOnline { get; set; } = true;
    [Parameter] public bool IsAnimated { get; set; } = true;
    [Parameter(CaptureUnmatchedValues = true)] 
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    public enum AvatarSize 
    { 
        ExtraSmall, Small, Medium, Large, ExtraLarge 
    }

    protected string GetAvatarClasses()
    {
        var baseClasses = "relative inline-flex items-center justify-center overflow-hidden rounded-full border-2 border-primary/20 shadow-md";
        
        var sizeClasses = Size switch
        {
            AvatarSize.ExtraSmall => "w-6 h-6",
            AvatarSize.Small => "w-8 h-8",
            AvatarSize.Large => "w-12 h-12",
            AvatarSize.ExtraLarge => "w-16 h-16",
            _ => "w-10 h-10"
        };
        
        var animationClasses = IsAnimated ? "hover:shadow-lg transition-all duration-200 hover:scale-105" : "";
        var backgroundClasses = string.IsNullOrEmpty(ImageUrl) ? "bg-gradient-to-br from-primary to-secondary" : "";
        
        return $"{baseClasses} {sizeClasses} {animationClasses} {backgroundClasses}";
    }

    protected string GetImageClasses()
    {
        return "w-full h-full object-cover";
    }

    protected string GetInitialsClasses()
    {
        var textSizeClasses = Size switch
        {
            AvatarSize.ExtraSmall => "text-xs",
            AvatarSize.Small => "text-xs",
            AvatarSize.Large => "text-lg",
            AvatarSize.ExtraLarge => "text-xl",
            _ => "text-sm"
        };
        
        return $"text-white font-medium {textSizeClasses}";
    }

    protected string GetDefaultIconClasses()
    {
        var iconSizeClasses = Size switch
        {
            AvatarSize.ExtraSmall => "text-xs",
            AvatarSize.Small => "text-sm",
            AvatarSize.Large => "text-lg",
            AvatarSize.ExtraLarge => "text-xl",
            _ => "text-base"
        };
        
        return $"fas fa-user text-white {iconSizeClasses}";
    }

    protected string GetOnlineIndicatorClasses()
    {
        var baseClasses = "absolute border-2 border-white rounded-full";
        var statusClasses = IsOnline ? "bg-status-completed animate-pulse" : "bg-status-pending";
        
        var positionClasses = Size switch
        {
            AvatarSize.ExtraSmall => "-top-0.5 -right-0.5 w-2 h-2",
            AvatarSize.Small => "-top-0.5 -right-0.5 w-2.5 h-2.5",
            AvatarSize.Large => "-top-1 -right-1 w-4 h-4",
            AvatarSize.ExtraLarge => "-top-1 -right-1 w-5 h-5",
            _ => "-top-1 -right-1 w-3 h-3"
        };
        
        return $"{baseClasses} {statusClasses} {positionClasses}";
    }
}
