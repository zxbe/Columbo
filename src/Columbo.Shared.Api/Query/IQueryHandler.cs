using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Query
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
