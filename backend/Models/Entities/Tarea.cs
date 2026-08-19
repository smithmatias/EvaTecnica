using System.ComponentModel.DataAnnotations;

namespace EvaluacionDev.Models.Entities;

public class Tarea
{
    public int Id { get; set; }

    [MaxLength(150)]
    public string Titulo { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Descripcion { get; set; }

    public bool Completada { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public DateTime? FechaVencimiento { get; set; }

    public int UsuarioId { get; set; }

    public Usuario? Usuario { get; set; }
}
