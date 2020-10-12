using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Create and return an open sql connection.        
        /// </summary>
        public IDbConnection GetOpenConnection()
        {
            if (_connectionString == null) throw new NullReferenceException("Connection string can not be empty");

            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public async Task<IDbConnection> GetOpenConnectionAsync()
        {
            if (_connectionString == null) throw new NullReferenceException("Connection string can not be empty");

            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            return conn;
        }

        /// <summary>
        /// Attempt to re-use Database connection from a given transaction
        /// </summary>
        /// <param name="transaction">Nullable transaction</param>
        /// <param name="connectionWhenTransactionNull">The connection to be use if fail to get connection from the transaction</param>
        /// <returns></returns>
        public IDbConnection TryGetDbConnectionFromTransaction(IDbTransaction transaction,
            IDbConnection connectionWhenTransactionNull)
        {
            //If Transaction is not null then use connection associated to transaction; otherwise, use the other connection
            return transaction != null ? transaction.Connection : connectionWhenTransactionNull;
        }

    }
}
