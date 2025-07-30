using TaskFlowPro.Domain.Entities;
using TaskEntity = TaskFlowPro.Domain.Entities.Task;

namespace TaskFlowPro.Application.Interfaces;

/// <summary>
/// Service interface for team-related operations
/// </summary>
public interface ITeamService
{
    /// <summary>
    /// Gets all teams
    /// </summary>
    Task<IEnumerable<Team>> GetAllTeamsAsync();

    /// <summary>
    /// Gets a team by its ID
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<Team?> GetTeamByIdAsync(int teamId);

    /// <summary>
    /// Gets a team by its name
    /// </summary>
    /// <param name="teamName">Team name</param>
    Task<Team?> GetTeamByNameAsync(string teamName);

    /// <summary>
    /// Creates a new team
    /// </summary>
    /// <param name="team">Team to create</param>
    Task<Team> CreateTeamAsync(Team team);

    /// <summary>
    /// Updates an existing team
    /// </summary>
    /// <param name="team">Team to update</param>
    Task<Team> UpdateTeamAsync(Team team);

    /// <summary>
    /// Deletes a team
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<bool> DeleteTeamAsync(int teamId);

    /// <summary>
    /// Assigns a team leader
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    /// <param name="leaderId">User identifier for the new leader</param>
    Task<bool> AssignTeamLeaderAsync(int teamId, int leaderId);

    /// <summary>
    /// Removes the current team leader
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<bool> RemoveTeamLeaderAsync(int teamId);

    /// <summary>
    /// Gets all members of a team
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<IEnumerable<User>> GetTeamMembersAsync(int teamId);

    /// <summary>
    /// Gets all tasks assigned to a team
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<IEnumerable<TaskEntity>> GetTeamTasksAsync(int teamId);
}
