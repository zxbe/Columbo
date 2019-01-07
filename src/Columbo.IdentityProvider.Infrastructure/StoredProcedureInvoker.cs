using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Columbo.Shared.Infrastructure.Extensions;
using Columbo.Shared.Infrastructure;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace Columbo.IdentityProvider.Infrastructure
{
    public class StoredProcedureInvoker : IStoredProcedureInvoker<StoredProcedureEnum>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public StoredProcedureInvoker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public IEnumerable<T> Query<T>(IDynamicParameters parameters, StoredProcedureEnum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Execute(IDynamicParameters parameters, StoredProcedureEnum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                sqlConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
