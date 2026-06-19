using System.Data;
using System.Data.Common;

namespace NormMicroORMTest.Data;

public interface IConnectionFactory
{
    Task<DbConnection> CreateOpenAsync(CancellationToken ct = default);
}
