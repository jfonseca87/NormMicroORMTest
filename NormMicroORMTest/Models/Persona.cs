namespace NormMicroORMTest.Models;

public class Persona
{
    public int PersonaID { get; init; }
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string Documento { get; init; } = null!;
    public DateTime FechaNacimiento { get; init; }
    public string Email { get; init; } = null!;
    public string? Telefono { get; init; }
    public DateTime FechaRegistro { get; init; }
}
