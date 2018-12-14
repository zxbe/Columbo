using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Query
{
    public interface IQueryBus
    {
        TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
