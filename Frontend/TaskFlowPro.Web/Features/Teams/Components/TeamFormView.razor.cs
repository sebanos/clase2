using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Models.Teams;

namespace TaskFlowPro.Web.Features.Teams.Components;

/// <summary>
/// ESTUDIANTE: Base class para el formulario de equipos
///
/// OBJETIVOS DE APRENDIZAJE:
/// - Implementar formularios con múltiples campos
/// - Trabajar con dropdowns y selección de datos
/// - Filtrar datos para opciones específicas
/// - Validación de formularios complejos
/// </summary>
public partial class TeamFormViewBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    protected TeamFormModel formData = new();
    protected bool isLoading = false;
    protected string errorMessage = "";

    protected override void OnInitialized()
    {
        // TODO: ESTUDIANTE - Inicializar el formulario
        // Aquí puedes inicializar valores por defecto si es necesario
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar envío del formulario de equipo
    ///
    /// INSTRUCCIONES:
    /// 1. Limpiar errores previos
    /// 2. Validar campos requeridos (Name, Description)
    /// 3. Mostrar estado de carga
    /// 4. Simular llamada a API
    /// 5. Mostrar mensaje de éxito y navegar de vuelta
    /// 6. Manejar errores
    /// </summary>
    protected async Task HandleSubmit()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleSubmit()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación de vuelta
    /// </summary>
    protected void HandleBack()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleBack()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar obtención de líderes disponibles
    ///
    /// INSTRUCCIONES:
    /// 1. Obtener todos los usuarios usando MockDataService.GetMockUsers()
    /// 2. Filtrar solo usuarios con rol "team_leader" o "global_admin"
    /// 3. Retornar la lista filtrada
    ///
    /// PISTA: Usar .Where() con condición de roles
    /// </summary>
    protected List<MockUser> GetAvailableLeaders()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetAvailableLeaders()");
    }


}
