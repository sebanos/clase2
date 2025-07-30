using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Models.Tasks;

namespace TaskFlowPro.Web.Features.Tasks.Components;

/// <summary>
/// ESTUDIANTE: Base class para el formulario de tareas
///
/// OBJETIVOS DE APRENDIZAJE:
/// - Implementar formularios con lógica condicional
/// - Trabajar con contexto de usuario actual
/// - Filtrar datos basado en relaciones (equipo)
/// - Manejar navegación condicional
/// </summary>
public partial class TaskFormViewBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    protected TaskFormModel formData = new();
    protected bool isLoading = false;
    protected string errorMessage = "";

    protected override void OnInitialized()
    {
        // TODO: ESTUDIANTE - Inicializar el formulario
        // Puedes establecer valores por defecto aquí
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar envío del formulario de tarea
    ///
    /// INSTRUCCIONES:
    /// 1. Limpiar errores previos
    /// 2. Validar campos requeridos (Title, AssignedTo)
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
    /// TODO: ESTUDIANTE - Implementar navegación condicional de vuelta
    ///
    /// INSTRUCCIONES:
    /// 1. Si el usuario actual es "team_leader", navegar a "team-tasks"
    /// 2. Si no, navegar a "my-tasks"
    /// 3. Usar UIState.CurrentUser?.Role para verificar el rol
    /// </summary>
    protected void HandleBack()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleBack()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar obtención de miembros del equipo
    ///
    /// INSTRUCCIONES:
    /// 1. Verificar que UIState.CurrentUser?.TeamId no sea null
    /// 2. Si es null, retornar lista vacía
    /// 3. Obtener todos los usuarios y filtrar por TeamId
    /// 4. Retornar solo usuarios del mismo equipo
    /// </summary>
    protected List<MockUser> GetTeamMembers()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetTeamMembers()");
    }


}
