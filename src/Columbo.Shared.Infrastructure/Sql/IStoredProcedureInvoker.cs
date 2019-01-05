using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace Columbo.Shared.Infrastructure.Sql
{
    public interface IStoredProcedureInvoker<TEnum> where TEnum : struct // todo where TEnum : Enum
    {
        IEnumerable<T> Query<T>(IDynamicParameters parameters, TEnum storedProcedureEnum);
        void Execute(IDynamicParameters parameters, TEnum storedProcedureEnum);
    }
}
