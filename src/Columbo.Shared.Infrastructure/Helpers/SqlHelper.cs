using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Columbo.Shared.Infrastructure.Helpers
{
    public static class SqlHelper
    {
        public static bool CheckIfStoredProcedureExists(IDbConnection connection, string procedureName)
        {
            string sql = $"SELECT COUNT(*) FROM sys.procedures WHERE Name = '{procedureName}'";

            var result = connection.QuerySingle<int>(sql);

            return result != 0;
        }

        public static bool CheckIfTypeExists(IDbConnection connection, string typeName)
        {
            string sql = $"SELECT COUNT(*) FROM sys.types WHERE is_table_type = 1 AND name = '{typeName}'";

            var result = connection.QuerySingle<int>(sql);

            return result != 0;
        }
    }
}
