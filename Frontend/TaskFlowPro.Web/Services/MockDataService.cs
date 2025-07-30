namespace TaskFlowPro.Web.Services;

public static class MockDataService
{
    public static List<MockTask> GetMockTasks()
    {
        return new List<MockTask>
        {
            new MockTask
            {
                Id = "1",
                Title = "Implement user authentication system",
                Description = "Create secure login and registration functionality with JWT tokens and role-based access control",
                Status = "completed",
                AssignedTo = "3",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddDays(-7),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new MockTask
            {
                Id = "2",
                Title = "Design responsive task management UI",
                Description = "Create an intuitive and modern interface for task management with drag-and-drop functionality",
                Status = "pending",
                AssignedTo = "3",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-2)
            },
            new MockTask
            {
                Id = "3",
                Title = "Setup database schema and migrations",
                Description = "Design and implement the complete database structure with proper relationships and indexes",
                Status = "urgent",
                AssignedTo = "3",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = DateTime.Now.AddHours(-6)
            },
            new MockTask
            {
                Id = "4",
                Title = "Implement real-time notifications",
                Description = "Add SignalR-based real-time notifications for task updates and team collaboration",
                Status = "pending",
                AssignedTo = "3",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddHours(-12)
            },
            new MockTask
            {
                Id = "5",
                Title = "Create team dashboard analytics",
                Description = "Build comprehensive analytics dashboard showing team performance and task metrics",
                Status = "pending",
                AssignedTo = "4",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now.AddHours(-8)
            },
            new MockTask
            {
                Id = "4",
                Title = "Write API documentation",
                Description = "Document all API endpoints with examples and response formats",
                Status = "pending",
                AssignedTo = "3",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now.AddHours(-3)
            },
            new MockTask
            {
                Id = "5",
                Title = "Implement real-time notifications",
                Description = "Add SignalR for real-time task updates and notifications",
                Status = "pending",
                AssignedTo = "4",
                AssignedBy = "2",
                TeamId = "team1",
                CreatedAt = DateTime.Now.AddHours(-12),
                UpdatedAt = DateTime.Now.AddHours(-2)
            }
        };
    }

    public static List<MockUser> GetMockUsers()
    {
        return new List<MockUser>
        {
            new MockUser
            {
                Id = "1",
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@taskflow.com",
                Role = "global_admin",
                TeamId = null,
                TeamName = null
            },
            new MockUser
            {
                Id = "2",
                FirstName = "Team",
                LastName = "Leader",
                Email = "leader@taskflow.com",
                Role = "team_leader",
                TeamId = "team1",
                TeamName = "Development Team"
            },
            new MockUser
            {
                Id = "3",
                FirstName = "John",
                LastName = "Developer",
                Email = "john@taskflow.com",
                Role = "team_member",
                TeamId = "team1",
                TeamName = "Development Team"
            },
            new MockUser
            {
                Id = "4",
                FirstName = "Jane",
                LastName = "Designer",
                Email = "jane@taskflow.com",
                Role = "team_member",
                TeamId = "team1",
                TeamName = "Development Team"
            },
            new MockUser
            {
                Id = "5",
                FirstName = "Mike",
                LastName = "Tester",
                Email = "mike@taskflow.com",
                Role = "team_member",
                TeamId = "team2",
                TeamName = "QA Team"
            }
        };
    }

    public static List<MockTeam> GetMockTeams()
    {
        return new List<MockTeam>
        {
            new MockTeam
            {
                Id = "team1",
                Name = "Development Team",
                Description = "Main development team responsible for core features",
                LeaderId = "2",
                MemberCount = 3,
                CreatedAt = DateTime.Now.AddMonths(-6)
            },
            new MockTeam
            {
                Id = "team2",
                Name = "QA Team",
                Description = "Quality assurance and testing team",
                LeaderId = "5",
                MemberCount = 2,
                CreatedAt = DateTime.Now.AddMonths(-4)
            },
            new MockTeam
            {
                Id = "team3",
                Name = "Design Team",
                Description = "UI/UX design and user experience team",
                LeaderId = "4",
                MemberCount = 1,
                CreatedAt = DateTime.Now.AddMonths(-3)
            }
        };
    }
}

public class MockTask
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "pending"; // pending, completed, urgent
    public string AssignedTo { get; set; } = "";
    public string AssignedBy { get; set; } = "";
    public string TeamId { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class MockTeam
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string LeaderId { get; set; } = "";
    public int MemberCount { get; set; }
    public DateTime CreatedAt { get; set; }
}
