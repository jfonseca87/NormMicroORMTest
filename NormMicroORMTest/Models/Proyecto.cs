namespace NormMicroORMTest.Models;

public class Proyecto
{
    public Guid Id { get; set; }
    public string NombreProyecto { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTimeOffset FechaInicio { get; set; }
    public DateTimeOffset FechaFinPrevista { get; set; }
    public decimal Presupuesto { get; set; }
    public string Responsable { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public int Prioridad { get; set; }  
    public DateTimeOffset FechaCreacion { get; set; }
    public DateTimeOffset UltimaActualizacion { get; set; }
}
