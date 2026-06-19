using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace NormMicroORMTest.Data;

public sealed class SqlConnectionFactory(IConfiguration configuration) : IConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    public async Task<DbConnection> CreateOpenAsync(CancellationToken ct = default)
    {
        var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync(ct).ConfigureAwait(false);
        return conn;
    }
}
