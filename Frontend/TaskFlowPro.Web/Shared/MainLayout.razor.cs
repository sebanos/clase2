using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;

namespace TaskFlowPro.Web.Shared;

public partial class MainLayoutBase : LayoutComponentBase, IDisposable
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    protected override void OnInitialized()
    {
        UIState.OnStateChanged += StateHasChanged;
        
        // Initialize mock data for demo
        if (UIState.CurrentUser == null)
        {
            ((UIStateService)UIState).InitializeMockData();
        }
    }

    public void Dispose()
    {
        UIState.OnStateChanged -= StateHasChanged;
    }
}
