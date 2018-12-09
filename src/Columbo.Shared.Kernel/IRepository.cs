using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel
{
    public interface IRepository<TEntity> where TEntity : ManagedBaseEntity
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
