namespace NormMicroORMTest.Models;

public class Direccion
{
    public int DireccionID { get; init; }
    public int PersonalID { get; init; }
    public string Linea1 { get; init; } = null!;
    public string Ciudad { get; init; } = null!;
    public string EstadoProvincia { get; init; } = null!;
    public string CodigoPostal { get; init; } = null!;
    public string Pais { get; init; } = null!;
    public string Tipo { get; init; } = null!;
}
