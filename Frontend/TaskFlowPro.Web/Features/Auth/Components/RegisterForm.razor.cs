using Microsoft.AspNetCore.Components;
using TaskFlowPro.Web.Services;
using TaskFlowPro.Web.Models.Auth;

namespace TaskFlowPro.Web.Features.Auth.Components;

/// <summary>
/// ESTUDIANTE: Base class para el formulario de registro
/// 
/// OBJETIVOS DE APRENDIZAJE:
/// - Implementar formularios complejos con múltiples campos
/// - Manejar validación de contraseñas coincidentes
/// - Trabajar con múltiples estados de visibilidad
/// - Implementar registro de usuarios
/// </summary>
public partial class RegisterFormBase : ComponentBase
{
    [Inject] protected IUIStateService UIState { get; set; } = null!;
    
    [Parameter] public EventCallback OnSwitchToLogin { get; set; }
    
    protected RegisterFormModel formData = new();
    protected bool showPassword = false;
    protected bool showConfirmPassword = false;
    protected bool isLoading = false;
    protected string errorMessage = "";

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar manejo del envío del formulario de registro
    /// 
    /// INSTRUCCIONES:
    /// 1. Limpiar errores previos
    /// 2. Validar que todos los campos requeridos estén llenos
    /// 3. Validar que Password y ConfirmPassword coincidan
    /// 4. Mostrar estado de carga
    /// 5. Simular llamada a API (Task.Delay)
    /// 6. Mostrar mensaje de éxito y cambiar a login
    /// 7. Manejar errores apropiadamente
    /// 
    /// VALIDACIONES REQUERIDAS:
    /// - FirstName, LastName, Email, Password no vacíos
    /// - Password == ConfirmPassword
    /// </summary>
    protected async Task HandleSubmit()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar HandleSubmit()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar toggle de visibilidad de password
    /// </summary>
    protected void TogglePasswordVisibility()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar TogglePasswordVisibility()");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar toggle de visibilidad de confirm password
    /// </summary>
    protected void ToggleConfirmPasswordVisibility()
    {
        // TODO: ESTUDIANTE - Implementar aquí
        throw new NotImplementedException("Estudiante debe implementar ToggleConfirmPasswordVisibility()");
    }


}
