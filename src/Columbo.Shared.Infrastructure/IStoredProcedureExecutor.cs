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
        IEnumerable<TFirst> Execute<TFirst, TSecond>(IDynamicParameters parameters, Enum storedProcedureEnum, bool oneToMany = false, string splitOn = "Id");
        T ExecuteSingleOrDefault<T>(IDynamicParameters parameters, Enum storedProcedureEnum);
    }
}
