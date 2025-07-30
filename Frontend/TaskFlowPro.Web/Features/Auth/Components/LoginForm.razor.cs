using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Models.Auth;

namespace TaskFlowPro.Web.Features.Auth.Components;

/// <summary>
/// ESTUDIANTE: Base class para el formulario de login
///
/// OBJETIVOS DE APRENDIZAJE:
/// - Implementar formularios de autenticación
/// - Manejar validación de credenciales
/// - Trabajar con estados de carga
/// - Implementar navegación condicional basada en roles
/// - Manejar errores de autenticación
/// </summary>
public partial class LoginFormBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    [Parameter] public EventCallback OnSwitchToRegister { get; set; }

    protected LoginFormModel formData = new();
    protected bool showPassword = false;
    protected bool isLoading = false;
    protected string errorMessage = "";

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar manejo del envío del formulario
    ///
    /// INSTRUCCIONES:
    /// 1. Limpiar errores previos
    /// 2. Validar que email y password no estén vacíos
    /// 3. Mostrar estado de carga
    /// 4. Llamar a GetMockUser() para autenticar
    /// 5. Si el usuario existe, usar UIState.SetCurrentUser() y navegar
    /// 6. Si no existe, mostrar error
    /// 7. Manejar excepciones apropiadamente
    ///
    /// NAVEGACIÓN POR ROL:
    /// - global_admin -> "users"
    /// - team_leader -> "team-tasks"
    /// - team_member -> "my-tasks"
    /// </summary>
    protected async Task HandleSubmit()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleSubmit()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar toggle de visibilidad de password
    ///
    /// INSTRUCCIONES:
    /// 1. Cambiar el valor de showPassword (true/false)
    /// </summary>
    protected void TogglePasswordVisibility()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar TogglePasswordVisibility()");
    }

    /// <summary>
    /// HELPER: Obtener nombres amigables para las vistas
    /// </summary>
    protected string GetViewDisplayName(string view)
    {
        return view switch
        {
            "users" => "User Management",
            "teams" => "Team Management",
            "team-tasks" => "Team Tasks",
            "my-tasks" => "My Tasks",
            _ => view
        };
    }

    /// <summary>
    /// HELPER: Autenticación mock - NO MODIFICAR
    /// Este método simula la autenticación con usuarios de prueba
    /// </summary>
    protected MockUser? GetMockUser(string email)
    {
        return email.ToLower() switch
        {
            "admin@taskflow.com" => new MockUser
            {
                Id = "1",
                FirstName = "Admin",
                LastName = "User",
                Email = email,
                Role = "global_admin",
                TeamId = null,
                TeamName = null
            },
            "leader@taskflow.com" => new MockUser
            {
                Id = "2",
                FirstName = "Team",
                LastName = "Leader",
                Email = email,
                Role = "team_leader",
                TeamId = "team1",
                TeamName = "Development Team"
            },
            "member@taskflow.com" => new MockUser
            {
                Id = "3",
                FirstName = "Team",
                LastName = "Member",
                Email = email,
                Role = "team_member",
                TeamId = "team1",
                TeamName = "Development Team"
            },
            _ => null
        };
    }


}
