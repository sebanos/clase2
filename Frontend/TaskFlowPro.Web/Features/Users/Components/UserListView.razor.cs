using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Components.UI;

namespace TaskFlowPro.Web.Features.Users.Components;

/// <summary>
/// ESTUDIANTE: Base class para el componente UserListView
///
/// OBJETIVOS DE APRENDIZAJE:
/// - Implementar el patrón CodeBehind en Blazor
/// - Manejar el ciclo de vida de componentes
/// - Implementar inyección de dependencias
/// - Trabajar con listas y datos mock
/// - Manejar eventos de UI
/// </summary>
public partial class UserListViewBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    protected List<MockUser> users = new();

    protected override void OnInitialized()
    {
        // TODO: ESTUDIANTE - Implementar carga inicial de usuarios
        // Llamar al método LoadUsers() aquí
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar carga de usuarios
    ///
    /// INSTRUCCIONES:
    /// 1. Usar MockDataService.GetMockUsers() para obtener los datos
    /// 2. Asignar el resultado a la propiedad 'users'
    /// 3. Considerar manejo de errores
    /// </summary>
    protected void LoadUsers()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar LoadUsers()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar obtención de iniciales de usuario
    ///
    /// INSTRUCCIONES:
    /// 1. Tomar la primera letra del FirstName
    /// 2. Tomar la primera letra del LastName
    /// 3. Concatenar y retornar
    /// </summary>
    protected string GetUserInitials(MockUser user)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetUserInitials()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar mapeo de roles a variantes de Badge
    ///
    /// INSTRUCCIONES:
    /// 1. Usar switch expression para mapear roles
    /// 2. global_admin -> Badge.BadgeVariant.Danger
    /// 3. team_leader -> Badge.BadgeVariant.Warning
    /// 4. team_member -> Badge.BadgeVariant.Primary
    /// 5. default -> Badge.BadgeVariant.Default
    /// </summary>
    protected Badge.BadgeVariant GetRoleBadgeVariant(string role)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetRoleBadgeVariant()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar nombres de display para roles
    ///
    /// INSTRUCCIONES:
    /// 1. Convertir roles técnicos a nombres amigables
    /// 2. global_admin -> "Global Admin"
    /// 3. team_leader -> "Team Leader"
    /// 4. team_member -> "Team Member"
    /// </summary>
    protected string GetRoleDisplayName(string role)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetRoleDisplayName()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación a formulario de creación
    ///
    /// INSTRUCCIONES:
    /// 1. Usar UIState.NavigateTo("user-form") para navegar
    /// </summary>
    protected void HandleCreateUser()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleCreateUser()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación a formulario de edición
    ///
    /// INSTRUCCIONES:
    /// 1. Navegar a "user-form"
    /// 2. Mostrar mensaje informativo con el ID del usuario
    /// 3. Usar UIState.ShowInfo() para el mensaje
    /// </summary>
    protected void HandleEditUser(string userId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleEditUser()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar eliminación de usuario
    ///
    /// INSTRUCCIONES:
    /// 1. Buscar el usuario en la lista por ID
    /// 2. Remover de la lista si existe
    /// 3. Mostrar mensaje de éxito
    /// 4. Llamar StateHasChanged() para actualizar UI
    /// </summary>
    protected void HandleDeleteUser(string userId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleDeleteUser()");
    }
}
