using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Repositories
{
    public interface IManagedBaseEntityRepository<TEntity> where TEntity : ManagedBaseEntity
    {
        TEntity GetById(int id);
        void Add(TEntity aggregateRoot);
        void Update(TEntity aggregateRoot);
        void Remove(TEntity entity);
    }
}
