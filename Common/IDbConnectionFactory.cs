using System.Data.Common;

namespace AutoInsurance.Common;

public interface IDbConnectionFactory
{
    Task<DbConnection> Create(CancellationToken cancellationToken);
}