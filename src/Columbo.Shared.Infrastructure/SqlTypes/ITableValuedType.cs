using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace Columbo.Shared.Infrastructure.SqlTypes
{
    public interface ITableValuedType
    {
    }

    public interface ITableValuedType<T> : ITableValuedType, IList<T>
    {
        ICustomQueryParameter AsTableValuedParameter();
    }
}
