using System.Data.Common;

namespace SeguroAutomotivo.Common;

public interface IDbConnectionFactory
{
    Task<DbConnection> Create(CancellationToken cancellationToken);
}