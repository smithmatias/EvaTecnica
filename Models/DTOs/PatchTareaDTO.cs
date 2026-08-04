namespace EvaluacionDev.Models.DTOs;

public class PatchTareaDTO
{
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public bool? Completada { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public int? UsuarioId { get; set; }
}
