using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace TaskFlowPro.Web.Components.UI;

public partial class InputBase : ComponentBase
{
    [Parameter] public string? Id { get; set; }
    [Parameter] public string? Label { get; set; }
    [Parameter] public string? Value { get; set; }
    [Parameter] public string Type { get; set; } = "text";
    [Parameter] public string? Placeholder { get; set; }
    [Parameter] public string? LeftIcon { get; set; }
    [Parameter] public string? RightIcon { get; set; }
    [Parameter] public string? HelperText { get; set; }
    [Parameter] public string? ErrorMessage { get; set; }
    [Parameter] public bool IsRequired { get; set; }
    [Parameter] public bool IsDisabled { get; set; }
    [Parameter] public bool IsReadOnly { get; set; }
    [Parameter] public InputSize Size { get; set; } = InputSize.Medium;
    [Parameter] public EventCallback<ChangeEventArgs> OnValueChanged { get; set; }
    [Parameter] public EventCallback<FocusEventArgs> OnFocus { get; set; }
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnRightIconClick { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] 
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    public enum InputSize { Small, Medium, Large }

    protected string GetContainerClasses()
    {
        return "space-y-2";
    }

    protected string GetLabelClasses()
    {
        return "block text-sm font-medium text-foreground/80";
    }

    protected string GetInputClasses()
    {
        var baseClasses = "block w-full rounded-md border transition-all duration-200 focus:outline-none focus:ring-2 focus:ring-primary focus:border-primary disabled:opacity-50 disabled:cursor-not-allowed";
        
        var sizeClasses = Size switch
        {
            InputSize.Small => "px-3 py-1.5 text-sm",
            InputSize.Large => "px-4 py-3 text-lg",
            _ => "px-3 py-2 text-sm"
        };
        
        var paddingClasses = "";
        if (!string.IsNullOrEmpty(LeftIcon))
        {
            paddingClasses += " pl-10";
        }
        if (!string.IsNullOrEmpty(RightIcon))
        {
            paddingClasses += " pr-10";
        }
        
        var borderClasses = !string.IsNullOrEmpty(ErrorMessage) 
            ? "border-red-300 focus:border-red-500 focus:ring-red-500" 
            : "border-border/50 focus:border-primary";
        
        var shadowClasses = "focus:shadow-lg focus:shadow-primary/10";
        
        return $"{baseClasses} {sizeClasses} {paddingClasses} {borderClasses} {shadowClasses}";
    }
}
