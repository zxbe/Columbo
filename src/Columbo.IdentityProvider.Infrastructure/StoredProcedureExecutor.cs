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
    public class StoredProcedureExecutor : IStoredProcedureExecutor
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public StoredProcedureExecutor(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public IEnumerable<T> Execute<T>(IDynamicParameters parameters, Enum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> Execute<T>(Enum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.Query<T>(procedureName, null, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<TFirs> Execute<TFirs, TSecond>(IDynamicParameters parameters, Func<TFirs, TSecond, TFirs> map, Enum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.Query(procedureName, map, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T ExecuteSingleOrDefault<T>(IDynamicParameters parameters, Enum storedProcedureEnum)
        {
            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.QuerySingleOrDefault<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }        
    }
}
