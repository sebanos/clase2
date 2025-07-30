using Microsoft.AspNetCore.Components;

namespace TaskFlowPro.Web.Components.UI;

public partial class LoadingSpinnerBase : ComponentBase
{
    [Parameter] public LoadingSize Size { get; set; } = LoadingSize.Medium;
    [Parameter] public LoadingVariant Variant { get; set; } = LoadingVariant.Primary;
    [Parameter] public string? Message { get; set; }
    [Parameter] public bool ShowOverlay { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] 
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    public enum LoadingSize { Small, Medium, Large }
    public enum LoadingVariant { Primary, Secondary, White }

    protected RenderFragment RenderSpinner() => __builder =>
    {
        __builder.OpenElement(0, "div");
        __builder.AddAttribute(1, "class", GetSpinnerClasses());

        __builder.OpenElement(2, "div");
        __builder.AddAttribute(3, "class", GetSpinnerInnerClasses());
        __builder.CloseElement();

        __builder.OpenElement(4, "div");
        __builder.AddAttribute(5, "class", GetSpinnerInnerClasses());
        __builder.AddAttribute(6, "style", "animation-delay: 0.1s");
        __builder.CloseElement();

        __builder.OpenElement(7, "div");
        __builder.AddAttribute(8, "class", GetSpinnerInnerClasses());
        __builder.AddAttribute(9, "style", "animation-delay: 0.2s");
        __builder.CloseElement();

        __builder.CloseElement();
    };

    protected string GetContainerClasses()
    {
        return "flex items-center justify-center";
    }

    protected string GetSpinnerContainerClasses()
    {
        return "bg-white rounded-lg p-6 shadow-xl flex flex-col items-center";
    }

    protected string GetInlineContainerClasses()
    {
        return "flex items-center";
    }

    protected string GetSpinnerClasses()
    {
        var baseClasses = "relative flex items-center justify-center";
        
        var sizeClasses = Size switch
        {
            LoadingSize.Small => "w-4 h-4",
            LoadingSize.Large => "w-8 h-8",
            _ => "w-6 h-6"
        };
        
        return $"{baseClasses} {sizeClasses}";
    }

    protected string GetSpinnerInnerClasses()
    {
        var baseClasses = "absolute rounded-full animate-pulse";
        
        var sizeClasses = Size switch
        {
            LoadingSize.Small => "w-4 h-4",
            LoadingSize.Large => "w-8 h-8",
            _ => "w-6 h-6"
        };
        
        var colorClasses = Variant switch
        {
            LoadingVariant.Secondary => "bg-secondary",
            LoadingVariant.White => "bg-white",
            _ => "bg-primary"
        };
        
        return $"{baseClasses} {sizeClasses} {colorClasses}";
    }
}
