using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Web.Models.Tasks;

/// <summary>
/// ESTUDIANTE: Modelo para el formulario de tarea
/// 
/// ARQUITECTURA LIMPIA:
/// - Modelo independiente de la UI
/// - Validaciones usando Data Annotations
/// - Reutilizable para diferentes contextos (crear/editar)
/// </summary>
public class TaskFormModel
{
    [Required(ErrorMessage = "Task title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = "";

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public string Status { get; set; } = "pending";

    /// <summary>
    /// ID del usuario asignado a la tarea (opcional)
    /// </summary>
    public string? AssignedTo { get; set; }

    /// <summary>
    /// Prioridad de la tarea
    /// </summary>
    public string Priority { get; set; } = "normal";

    /// <summary>
    /// Fecha límite para completar la tarea (opcional)
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Para edición: ID de la tarea que se está editando
    /// </summary>
    public int? TaskId { get; set; }

    /// <summary>
    /// ID del equipo al que pertenece la tarea
    /// </summary>
    public int? TeamId { get; set; }
}
