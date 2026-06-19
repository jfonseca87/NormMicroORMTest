using Norm;
using NormMicroORMTest.Data;
using NormMicroORMTest.Models;

namespace NormMicroORMTest.Repositories;

public class DashboardRepository(IConnectionFactory connectionFactory)
{
    public async Task<DashboardViewModel> GetDashboardAsync()
    {
        using var connection = await connectionFactory.CreateOpenAsync();
        
        // Norm.net magic: Multiple Result Sets in one go!
        // We execute two SELECT statements in a single batch.
        using var reader = await connection.ReadAsync(
            @"SELECT TOP 5 * FROM Proyectos ORDER BY Prioridad DESC;
              SELECT TOP 5 * FROM Persona ORDER BY FechaRegistro DESC");

        var dashboard = new DashboardViewModel();

        // Read the first result set (Projects)
        dashboard.HighPriorityProjects = await reader.ReadAsync<Proyecto>().ToListAsync();

        // Advance to the next result set and read it (People)
        if (await reader.NextResultAsync())
        {
            dashboard.RecentPeople = await reader.ReadAsync<Persona>().ToListAsync();
        }

        return dashboard;
    }
}
