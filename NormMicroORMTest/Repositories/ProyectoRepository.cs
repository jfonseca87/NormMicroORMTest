using Norm;
using NormMicroORMTest.Data;
using NormMicroORMTest.Models;

namespace NormMicroORMTest.Repositories;

public class ProyectoRepository(IConnectionFactory connectionFactory)
{
    public async Task<IEnumerable<Proyecto>> GetAllProjectsAsync()
    {
        using var connection = await connectionFactory.CreateOpenAsync();
        var result = await connection.ReadAsync<Proyecto>(
            @"SELECT TOP 1000 ID
                           ,NombreProyecto
                           ,Descripcion
                           ,FechaInicio
                           ,FechaFinPrevista
                           ,Presupuesto
                           ,Responsable
                           ,Cliente
                           ,Estado
                           ,Prioridad
                           ,FechaCreacion
                           ,UltimaActualizacion
                     FROM Proyectos
                     WHERE Prioridad = @Prioridad"
            , new { Prioridad = 3 })
            .ToListAsync();
        return result;
    }
}
