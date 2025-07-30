using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Components.UI;

namespace TaskFlowPro.Web.Components.Layout;

public partial class HeaderBase : ComponentBase, IDisposable
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;
    
    protected bool ShowUserMenu { get; set; } = false;

    protected override void OnInitialized()
    {
        UIState.OnStateChanged += StateHasChanged;
    }

    public void Dispose()
    {
        UIState.OnStateChanged -= StateHasChanged;
    }

    protected void ToggleUserMenu()
    {
        ShowUserMenu = !ShowUserMenu;
    }

    protected void HandleLogout()
    {
        ShowUserMenu = false;
        UIState.Logout();
    }

    protected string GetDefaultView()
    {
        return UIState.CurrentUser?.Role == "global_admin" ? "users" : "my-tasks";
    }

    protected List<NavigationItem> GetNavigationItems()
    {
        var items = new List<NavigationItem>();
        
        if (UIState.CurrentUser?.Role == "global_admin")
        {
            items.Add(new("users", "User Management", "fas fa-users"));
            items.Add(new("teams", "Team Management", "fas fa-users-cog"));
        }
        
        if (UIState.CurrentUser?.Role == "team_leader")
        {
            items.Add(new("team-tasks", "Team Tasks", "fas fa-tasks"));
        }
        
        items.Add(new("my-tasks", "My Tasks", "fas fa-check-square"));
        
        return items;
    }

    protected bool IsActiveView(string view)
    {
        return UIState.CurrentView == view;
    }

    protected string GetNavButtonClasses(string view)
    {
        var baseClasses = "nav-button";
        var activeClass = IsActiveView(view) ? "active" : "";
        return $"{baseClasses} {activeClass}";
    }

    protected Badge.BadgeVariant GetRoleBadgeVariant(string role)
    {
        return role switch
        {
            "global_admin" => Badge.BadgeVariant.Danger,
            "team_leader" => Badge.BadgeVariant.Warning,
            "team_member" => Badge.BadgeVariant.Primary,
            _ => Badge.BadgeVariant.Default
        };
    }

    protected string GetRoleDisplayName(string role)
    {
        return role switch
        {
            "global_admin" => "Global Admin",
            "team_leader" => "Team Leader",
            "team_member" => "Team Member",
            _ => role
        };
    }

    protected string GetUserInitials()
    {
        if (UIState.CurrentUser == null) return "U";
        return $"{UIState.CurrentUser.FirstName.FirstOrDefault()}{UIState.CurrentUser.LastName.FirstOrDefault()}";
    }

    protected record NavigationItem(string View, string Label, string Icon);
}
