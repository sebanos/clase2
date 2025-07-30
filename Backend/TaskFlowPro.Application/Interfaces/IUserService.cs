using TaskFlowPro.Domain.Entities;

namespace TaskFlowPro.Application.Interfaces;

/// <summary>
/// Service interface for user-related operations
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets all users
    /// </summary>
    Task<IEnumerable<User>> GetAllUsersAsync();

    /// <summary>
    /// Gets a user by their ID
    /// </summary>
    /// <param name="userId">User identifier</param>
    Task<User?> GetUserByIdAsync(int userId);

    /// <summary>
    /// Gets a user by their email address
    /// </summary>
    /// <param name="email">Email address</param>
    Task<User?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Gets all users in a specific team
    /// </summary>
    /// <param name="teamId">Team identifier</param>
    Task<IEnumerable<User>> GetUsersByTeamAsync(int teamId);

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="user">User to create</param>
    Task<User> CreateUserAsync(User user);

    /// <summary>
    /// Updates an existing user
    /// </summary>
    /// <param name="user">User to update</param>
    Task<User> UpdateUserAsync(User user);

    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="userId">User identifier</param>
    Task<bool> DeleteUserAsync(int userId);

    /// <summary>
    /// Assigns a user to a team
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <param name="teamId">Team identifier</param>
    Task<bool> AssignUserToTeamAsync(int userId, int teamId);

    /// <summary>
    /// Removes a user from their current team
    /// </summary>
    /// <param name="userId">User identifier</param>
    Task<bool> RemoveUserFromTeamAsync(int userId);

    /// <summary>
    /// Changes a user's role
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <param name="roleId">New role identifier</param>
    Task<bool> ChangeUserRoleAsync(int userId, int roleId);

    /// <summary>
    /// Validates user credentials for authentication
    /// </summary>
    /// <param name="email">Email address</param>
    /// <param name="password">Password</param>
    Task<User?> ValidateUserCredentialsAsync(string email, string password);

    /// <summary>
    /// Invalidates all JWT tokens for a user
    /// </summary>
    /// <param name="userId">User identifier</param>
    System.Threading.Tasks.Task InvalidateUserTokensAsync(int userId);
}
