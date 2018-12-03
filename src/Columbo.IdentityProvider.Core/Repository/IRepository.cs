using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Repository
{
    public interface IRepository<TRoot> where TRoot : AggregateRoot
    {
        TRoot GetById(int id);
        void Update(TRoot root);
    }
}
