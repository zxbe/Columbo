using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace Columbo.Shared.Infrastructure
{
    public interface IStoredProcedureExecutor
    {
        IEnumerable<T> Execute<T>(IDynamicParameters parameters, Enum storedProcedureEnum);
        IEnumerable<T> Execute<T>(Enum storedProcedureEnum);
        IEnumerable<TFirst> Execute<TFirst, TSecond>(IDynamicParameters parameters, Func<TFirst, TSecond, TFirst> map, Enum storedProcedureEnum);
        T ExecuteSingleOrDefault<T>(IDynamicParameters parameters, Enum storedProcedureEnum);
    }
}
