using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Web.Models.Auth;

/// <summary>
/// ESTUDIANTE: Modelo para el formulario de login
/// 
/// ARQUITECTURA LIMPIA:
/// - Los modelos de formulario están separados de la lógica de componentes
/// - Incluyen validaciones usando Data Annotations
/// - Son reutilizables en diferentes partes de la aplicación
/// </summary>
public class LoginFormModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = "";

    public bool RememberMe { get; set; } = false;
}
