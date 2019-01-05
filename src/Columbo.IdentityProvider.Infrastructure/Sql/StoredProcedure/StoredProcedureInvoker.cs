using Columbo.Shared.Infrastructure.Extensions;
using Columbo.Shared.Infrastructure.Sql;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Sql.StoredProcedure
{
    public class StoredProcedureInvoker : IStoredProcedureInvoker<StoredProcedureEnum>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public StoredProcedureInvoker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public IEnumerable<T> Query<T>(SqlMapper.IDynamicParameters parameters, StoredProcedureEnum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Execute(SqlMapper.IDynamicParameters parameters, StoredProcedureEnum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                sqlConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
