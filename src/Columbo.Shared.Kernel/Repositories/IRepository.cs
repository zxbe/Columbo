using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Repositories
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot GetById(int id);
        void Add(TAggregateRoot aggregateRoot);
        void Update(TAggregateRoot aggregateRoot);
        void Archive(TAggregateRoot aggregateRoot);
    }
}
