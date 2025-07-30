using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;

namespace TaskFlowPro.Web.Components.Layout;

/// <summary>
/// ESTUDIANTE: Router principal de la aplicación
/// 
/// OBJETIVOS DE APRENDIZAJE:
/// - Entender el patrón de enrutamiento en Blazor
/// - Manejar suscripciones a eventos
/// - Implementar IDisposable correctamente
/// - Gestionar el estado de la aplicación
/// </summary>
public partial class AppRouterBase : ComponentBase, IDisposable
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;

    /// <summary>
    /// Inicialización del componente
    /// Suscribirse a eventos del UIState para reaccionar a cambios
    /// </summary>
    protected override void OnInitialized()
    {
        UIState.OnStateChanged += StateHasChanged;
        UIState.OnViewChanged += OnViewChanged;
    }

    /// <summary>
    /// Limpieza de recursos
    /// Desuscribirse de eventos para evitar memory leaks
    /// </summary>
    public void Dispose()
    {
        UIState.OnStateChanged -= StateHasChanged;
        UIState.OnViewChanged -= OnViewChanged;
    }

    /// <summary>
    /// Manejar cambios de vista
    /// Forzar re-renderizado cuando cambia la vista
    /// </summary>
    private void OnViewChanged(string view)
    {
        StateHasChanged();
    }
}
