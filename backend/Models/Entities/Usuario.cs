using System.ComponentModel.DataAnnotations;

namespace EvaluacionDev.Models.Entities;

public class Usuario
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;

    public DateTime FechaAlta { get; set; } = DateTime.UtcNow;

    public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
