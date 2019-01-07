using Columbo.Shared.Infrastructure;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure
{
    public class SqlScriptExecutor : ISqlScriptExecutor
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public SqlScriptExecutor(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public void Execute(string sql)
        {
            using (var connection = _sqlConnectionFactory.Create())
            {
                ServerConnection serverConnection = new ServerConnection(connection);
                Server server = new Server(serverConnection);

                server.ConnectionContext.ExecuteNonQuery(sql);
            }
        }

        public void Execute(string sql, SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("The sql connection is null");

            ServerConnection serverConnection = new ServerConnection(connection);
            Server server = new Server(serverConnection);

            server.ConnectionContext.ExecuteNonQuery(sql);
        }
    }
}
