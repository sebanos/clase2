using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;

namespace TaskFlowPro.Web.Features.Teams.Components;

/// <summary>
/// ESTUDIANTE: Base class para el componente TeamListView
///
/// OBJETIVOS DE APRENDIZAJE:
/// - Manejar múltiples fuentes de datos (teams y users)
/// - Implementar cálculos de tiempo relativo
/// - Trabajar con relaciones entre entidades
/// - Implementar operaciones CRUD básicas
/// </summary>
public partial class TeamListViewBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    protected List<MockTeam> teams = new();
    protected List<MockUser> users = new();

    protected override void OnInitialized()
    {
        // TODO: ESTUDIANTE - Implementar carga inicial de datos
        // Llamar al método LoadData() aquí
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar carga de datos
    ///
    /// INSTRUCCIONES:
    /// 1. Cargar teams usando MockDataService.GetMockTeams()
    /// 2. Cargar users usando MockDataService.GetMockUsers()
    /// 3. Asignar a las propiedades correspondientes
    /// </summary>
    protected void LoadData()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar LoadData()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar obtención del nombre del líder
    ///
    /// INSTRUCCIONES:
    /// 1. Buscar el usuario en la lista 'users' por leaderId
    /// 2. Si existe, retornar "FirstName LastName"
    /// 3. Si no existe, retornar "No leader assigned"
    /// </summary>
    protected string GetTeamLeaderName(string leaderId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetTeamLeaderName()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar cálculo de tiempo relativo
    ///
    /// INSTRUCCIONES:
    /// 1. Calcular diferencia entre DateTime.Now y createdAt
    /// 2. Si >= 30 días, mostrar meses
    /// 3. Si >= 1 día, mostrar días
    /// 4. Si >= 1 hora, mostrar horas
    /// 5. Sino, mostrar "Today"
    /// </summary>
    protected string GetTimeAgo(DateTime createdAt)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar GetTimeAgo()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación a formulario de creación
    /// </summary>
    protected void HandleCreateTeam()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleCreateTeam()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación a formulario de edición
    /// </summary>
    protected void HandleEditTeam(string teamId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleEditTeam()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar eliminación de equipo
    /// </summary>
    protected void HandleDeleteTeam(string teamId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleDeleteTeam()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar navegación a tareas del equipo
    /// </summary>
    protected void HandleViewTasks(string teamId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleViewTasks()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar vista de miembros (funcionalidad futura)
    /// </summary>
    protected void HandleViewMembers(string teamId)
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleViewMembers()");
    }
}
