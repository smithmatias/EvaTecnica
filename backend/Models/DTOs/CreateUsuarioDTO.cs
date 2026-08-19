namespace EvaluacionDev.Models.DTOs;

public class CreateUsuarioDTO
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;
}
