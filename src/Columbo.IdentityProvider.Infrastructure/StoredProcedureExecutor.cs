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
using System.Linq;

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

        public IEnumerable<TFirst> Execute<TFirst, TSecond>(IDynamicParameters parameters, Enum storedProcedureEnum, bool oneToMany = false, string splitOn = "Id")
        {
            Func<TFirst, TSecond, TFirst> map = null;

            if (oneToMany)
            {
                var rootObjects = new Dictionary<int, TFirst>();

                map = (first, second) =>
                {
                    TFirst firstEntry;

                    if (!rootObjects.TryGetValue(first.GetHashCode(), out firstEntry))
                    {
                        firstEntry = first;
                        rootObjects.Add(firstEntry.GetHashCode(), firstEntry);
                    }

                    var collectionPropertyInfo = firstEntry.GetType().GetProperties()
                        .Single(x => x.PropertyType.IsAssignableFrom(typeof(ICollection<TSecond>)));

                    var collection = (ICollection<TSecond>)collectionPropertyInfo.GetValue(firstEntry);
                    collection.Add(second);

                    return firstEntry;
                };
            }
            else
            {
                map = (first, second) =>
                {
                    var typeOfSecond = typeof(TSecond);

                    var propertyOfSecondType = first.GetType().GetProperties().Single(x => x.PropertyType == typeOfSecond);
                    propertyOfSecondType.SetValue(first, second);

                    return first;
                };
            }

            using (var sqlConnection = _sqlConnectionFactory.Create())
            {
                var procedureName = storedProcedureEnum.GetSqlScriptInfo().Name;
                return sqlConnection.Query(procedureName, map, parameters, commandType: CommandType.StoredProcedure, splitOn: splitOn).Distinct();
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
