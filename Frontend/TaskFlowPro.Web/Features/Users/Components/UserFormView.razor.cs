using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Models.Users;

namespace TaskFlowPro.Web.Features.Users.Components;

/// <summary>
/// ESTUDIANTE: Base class para el formulario de usuarios
///
/// OBJETIVOS DE APRENDIZAJE:
/// - Implementar formularios en Blazor
/// - Manejar validación de datos
/// - Trabajar con estados de carga
/// - Implementar navegación entre vistas
/// - Manejar errores y mensajes de usuario
/// </summary>
public partial class UserFormViewBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    protected UserFormModel formData = new();
    protected bool isLoading = false;
    protected string errorMessage = "";

    protected override void OnInitialized()
    {
        // TODO: ESTUDIANTE - Inicializar el formulario
        // Aquí puedes inicializar valores por defecto si es necesario
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar envío del formulario
    ///
    /// INSTRUCCIONES:
    /// 1. Limpiar mensajes de error previos
    /// 2. Validar que todos los campos requeridos estén llenos
    /// 3. Mostrar estado de carga
    /// 4. Simular llamada a API (usar Task.Delay)
    /// 5. Mostrar mensaje de éxito y navegar de vuelta
    /// 6. Manejar errores apropiadamente
    ///
    /// CAMPOS REQUERIDOS: FirstName, LastName, Email, Role
    /// </summary>
    protected async Task HandleSubmit()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleSubmit()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación de vuelta
    ///
    /// INSTRUCCIONES:
    /// 1. Usar UIState.NavigateTo("users") para volver a la lista
    /// </summary>
    protected void HandleBack()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleBack()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar obtención de equipos
    ///
    /// INSTRUCCIONES:
    /// 1. Usar MockDataService.GetMockTeams() para obtener la lista
    /// 2. Retornar la lista para usar en el dropdown
    /// </summary>
    protected List<MockTeam> GetTeams()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetTeams()");
    }


}
