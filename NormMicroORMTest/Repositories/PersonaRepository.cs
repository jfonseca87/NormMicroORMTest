using Norm;
using NormMicroORMTest.Data;
using NormMicroORMTest.Models;

namespace NormMicroORMTest.Repositories;

public class PersonaRepository(IConnectionFactory connectionFactory)
{
    public async Task<IEnumerable<Persona>> GetAllPersonasAsync()
    {
        using var connection = await connectionFactory.CreateOpenAsync();
        var result = await connection.ReadAsync<Persona>(
            @"SELECT *
                     FROM Persona")
            .ToListAsync();
        return result;
    }
}
