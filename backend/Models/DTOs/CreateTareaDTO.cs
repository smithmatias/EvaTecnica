namespace EvaluacionDev.Models.DTOs;

public class CreateTareaDTO
{
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public int UsuarioId { get; set; }
}
