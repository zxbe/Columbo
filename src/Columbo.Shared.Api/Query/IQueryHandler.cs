using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Query
{
    public interface IQueryHanfler
    {
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHanfler where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
