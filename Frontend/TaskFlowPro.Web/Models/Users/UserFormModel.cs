using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Web.Models.Users;

/// <summary>
/// ESTUDIANTE: Modelo para el formulario de usuario
/// 
/// ARQUITECTURA LIMPIA:
/// - Modelo separado de la lógica del componente
/// - Validaciones usando Data Annotations
/// - Reutilizable para crear y editar usuarios
/// </summary>
public class UserFormModel
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; } = "";

    /// <summary>
    /// ID del equipo al que pertenece el usuario (opcional)
    /// </summary>
    public string? TeamId { get; set; }

    /// <summary>
    /// Para edición: ID del usuario que se está editando
    /// </summary>
    public int? UserId { get; set; }
}
