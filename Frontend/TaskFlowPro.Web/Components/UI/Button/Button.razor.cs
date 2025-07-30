using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace TaskFlowPro.Web.Components.UI;

public partial class ButtonBase : ComponentBase
{
    [Parameter] public string Type { get; set; } = "button";
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Default;
    [Parameter] public ButtonSize Size { get; set; } = ButtonSize.Default;
    [Parameter] public bool IsDisabled { get; set; }
    [Parameter] public bool IsLoading { get; set; }
    [Parameter] public string Icon { get; set; } = string.Empty;
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected async Task HandleClick(MouseEventArgs e)
    {
        if (!IsDisabled && !IsLoading)
        {
            await OnClick.InvokeAsync(e);
        }
    }

    protected string GetButtonClasses()
    {
        var baseClasses = "inline-flex items-center justify-center font-medium rounded-md transition-all duration-200 focus:outline-none focus:ring-2 focus:ring-offset-2 disabled:opacity-50 disabled:cursor-not-allowed";
        
        var variantClasses = Variant switch
        {
            ButtonVariant.Primary => "bg-primary text-primary-foreground hover:bg-primary/90 focus:ring-primary",
            ButtonVariant.Secondary => "bg-secondary text-secondary-foreground hover:bg-secondary/80 focus:ring-secondary",
            ButtonVariant.Danger => "bg-destructive text-destructive-foreground hover:bg-destructive/90 focus:ring-destructive",
            ButtonVariant.Ghost => "hover:bg-accent hover:text-accent-foreground focus:ring-accent",
            ButtonVariant.Outline => "border border-input bg-background hover:bg-accent hover:text-accent-foreground focus:ring-accent",
            _ => "bg-background text-foreground hover:bg-accent hover:text-accent-foreground focus:ring-accent"
        };

        var sizeClasses = Size switch
        {
            ButtonSize.Small => "h-8 px-3 text-sm",
            ButtonSize.Large => "h-12 px-8 text-lg",
            _ => "h-10 px-4 text-base"
        };

        return $"{baseClasses} {variantClasses} {sizeClasses}";
    }

    public enum ButtonVariant
    {
        Default,
        Primary,
        Secondary,
        Danger,
        Ghost,
        Outline
    }

    public enum ButtonSize
    {
        Small,
        Default,
        Large
    }
}
