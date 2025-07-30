using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Web.Models.Teams;

/// <summary>
/// ESTUDIANTE: Modelo para el formulario de equipo
/// 
/// ARQUITECTURA LIMPIA:
/// - Separación clara entre modelo de datos y lógica de presentación
/// - Validaciones centralizadas y reutilizables
/// - Fácil testing y mantenimiento
/// </summary>
public class TeamFormModel
{
    [Required(ErrorMessage = "Team name is required")]
    [StringLength(100, ErrorMessage = "Team name cannot exceed 100 characters")]
    public string Name { get; set; } = "";

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Team leader is required")]
    public string LeaderId { get; set; } = "";

    /// <summary>
    /// Para edición: ID del equipo que se está editando
    /// </summary>
    public int? TeamId { get; set; }
}
