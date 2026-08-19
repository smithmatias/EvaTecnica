namespace EvaluacionDev.Models.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; }
}
