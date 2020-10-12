using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection GetOpenConnection();
        Task<IDbConnection> GetOpenConnectionAsync();
        IDbConnection TryGetDbConnectionFromTransaction(IDbTransaction transaction, IDbConnection connectionWhenTransactionNull);
    }
}
