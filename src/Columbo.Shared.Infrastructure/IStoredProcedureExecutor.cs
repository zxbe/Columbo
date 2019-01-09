using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace Columbo.Shared.Infrastructure
{
    public interface IStoredProcedureExecutor<TEnum> where TEnum : struct // todo where TEnum : Enum
    {
        IEnumerable<T> Execute<T>(IDynamicParameters parameters, TEnum storedProcedureEnum);
        IEnumerable<T> Execute<T>(TEnum storedProcedureEnum);
        T ExecuteSingle<T>(IDynamicParameters parameters, TEnum storedProcedureEnum);
    }
}
