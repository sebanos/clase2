using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;

namespace TaskFlowPro.Web.Features.Tasks.Components;

public partial class TaskListViewBase : ComponentBase, IDisposable
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;
    
    [Parameter] public bool IsTeamView { get; set; }
    
    protected List<MockTask> AllTasks { get; set; } = new();
    protected List<MockTask> FilteredTasks { get; set; } = new();
    protected List<MockUser> AllUsers { get; set; } = new();
    protected bool IsLoading { get; set; } = true;
    
    private string _searchTerm = "";
    private string _statusFilter = "all";
    private string _assigneeFilter = "all";
    
    protected string SearchTerm
    {
        get => _searchTerm;
        set
        {
            _searchTerm = value;
            FilterTasks();
        }
    }
    
    protected string StatusFilter
    {
        get => _statusFilter;
        set
        {
            _statusFilter = value;
            FilterTasks();
        }
    }
    
    protected string AssigneeFilter
    {
        get => _assigneeFilter;
        set
        {
            _assigneeFilter = value;
            FilterTasks();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        UIState.OnStateChanged += StateHasChanged;
        await LoadData();
    }

    public void Dispose()
    {
        UIState.OnStateChanged -= StateHasChanged;
    }

    protected async Task LoadData()
    {
        IsLoading = true;
        StateHasChanged();
        
        // Simulate loading delay
        await System.Threading.Tasks.Task.Delay(800);
        
        AllTasks = MockDataService.GetMockTasks();
        AllUsers = MockDataService.GetMockUsers();
        
        FilterTasks();
        IsLoading = false;
        StateHasChanged();
    }

    protected void FilterTasks()
    {
        var relevantTasks = GetRelevantTasks();
        
        FilteredTasks = relevantTasks.Where(task =>
            (string.IsNullOrEmpty(_searchTerm) || 
             task.Title.Contains(_searchTerm, StringComparison.OrdinalIgnoreCase) ||
             task.Description.Contains(_searchTerm, StringComparison.OrdinalIgnoreCase)) &&
            (_statusFilter == "all" || task.Status == _statusFilter) &&
            (_assigneeFilter == "all" || task.AssignedTo == _assigneeFilter)
        ).OrderByDescending(t => t.UpdatedAt).ToList();
        
        StateHasChanged();
    }

    protected List<MockTask> GetRelevantTasks()
    {
        if (IsTeamView && UIState.CurrentUser?.Role == "team_leader")
        {
            return AllTasks.Where(t => t.TeamId == UIState.CurrentUser.TeamId).ToList();
        }
        else
        {
            return AllTasks.Where(t => t.AssignedTo == UIState.CurrentUser?.Id).ToList();
        }
    }

    protected List<MockUser> GetTeamMembers()
    {
        if (!IsTeamView || UIState.CurrentUser?.TeamId == null) return new();
        return AllUsers.Where(u => u.TeamId == UIState.CurrentUser.TeamId).ToList();
    }

    protected MockUser? GetAssignedUser(string userId)
    {
        return AllUsers.FirstOrDefault(u => u.Id == userId);
    }

    protected MockUser? GetAssignedByUser(string userId)
    {
        return AllUsers.FirstOrDefault(u => u.Id == userId);
    }

    protected string GetTitle()
    {
        if (IsTeamView)
        {
            var teamName = UIState.CurrentUser?.TeamName ?? "Team";
            return $"Tasks for {teamName}";
        }
        return "My Assigned Tasks";
    }

    protected string GetSubtitle()
    {
        return IsTeamView ? "Manage and track team tasks" : "View and update your assigned tasks";
    }

    protected string GetEmptyStateTitle()
    {
        if (HasActiveFilters())
            return "No tasks found matching your filters";
        return IsTeamView ? "No team tasks yet" : "No assigned tasks";
    }

    protected string GetEmptyStateDescription()
    {
        if (HasActiveFilters())
            return "Try adjusting your search or filter criteria";
        return IsTeamView ? "Create your first task to get started!" : "You have no assigned tasks at the moment.";
    }

    protected bool HasActiveFilters()
    {
        return !string.IsNullOrEmpty(_searchTerm) || _statusFilter != "all" || _assigneeFilter != "all";
    }

    protected bool CanCreateTasks()
    {
        return UIState.CurrentUser?.Role == "team_leader";
    }

    protected bool CanEditTasks()
    {
        return IsTeamView && UIState.CurrentUser?.Role == "team_leader";
    }

    protected void HandleCreateTask()
    {
        UIState.NavigateTo("task-form");
    }

    protected void HandleEditTask(string taskId)
    {
        UIState.NavigateTo("task-form");
        UIState.ShowInfo($"Editing task: {taskId}");
    }

    protected void HandleDeleteTask(string taskId)
    {
        var task = AllTasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            AllTasks.Remove(task);
            FilterTasks();
            UIState.ShowSuccess("Task deleted successfully");
        }
    }

    protected void HandleStatusToggle((string Id, string Status) args)
    {
        var task = AllTasks.FirstOrDefault(t => t.Id == args.Id);
        if (task != null)
        {
            task.Status = args.Status;
            task.UpdatedAt = DateTime.Now;
            FilterTasks();
            
            var message = args.Status == "completed" ? "Task completed!" : "Task status updated";
            UIState.ShowSuccess(message);
        }
    }
}
