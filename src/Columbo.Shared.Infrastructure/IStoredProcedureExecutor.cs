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
        IEnumerable<TFirs> Execute<TFirs, TSecond>(IDynamicParameters parameters, Func<TFirs, TSecond, TFirs> map, Enum storedProcedureEnum);
        T ExecuteSingle<T>(IDynamicParameters parameters, Enum storedProcedureEnum);
    }
}
