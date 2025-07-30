using Microsoft.AspNetCore.Components;

namespace TaskFlowPro.Web.Components.UI;

public partial class CardBase : ComponentBase
{
    [Parameter] public RenderFragment? Header { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public RenderFragment? Footer { get; set; }
    [Parameter] public bool HasShadow { get; set; } = true;
    [Parameter] public bool IsGlass { get; set; } = false;
    [Parameter] public bool IsAnimated { get; set; } = true;
    [Parameter] public string? CustomClass { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] 
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected string GetCardClasses()
    {
        var baseClasses = "bg-card text-card-foreground rounded-lg border";
        
        var shadowClasses = HasShadow ? "shadow-lg hover:shadow-xl" : "";
        var glassClasses = IsGlass ? "bg-white/80 backdrop-blur-sm" : "";
        var animationClasses = IsAnimated ? "transition-all duration-300 hover:scale-[1.02] animate-scaleIn" : "";
        
        var classes = $"{baseClasses} {shadowClasses} {glassClasses} {animationClasses}";
        
        if (!string.IsNullOrEmpty(CustomClass))
        {
            classes += $" {CustomClass}";
        }
        
        return classes.Trim();
    }

    protected string GetHeaderClasses()
    {
        return "px-6 py-4 border-b bg-gradient-to-r from-primary/5 to-accent/5 hover:from-primary/10 hover:to-accent/10 transition-all duration-300";
    }

    protected string GetContentClasses()
    {
        return "p-6";
    }

    protected string GetFooterClasses()
    {
        return "px-6 py-4 border-t bg-muted/20";
    }
}
