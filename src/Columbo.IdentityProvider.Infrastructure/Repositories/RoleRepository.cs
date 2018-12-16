using Columbo.IdentityProvider.Core.Domain;
using Columbo.IdentityProvider.Core.Repositories;
using Columbo.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public RoleRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Role entity)
        {
            _databaseContext.Attach(entity).State = EntityState.Added;
            _databaseContext.SaveChanges();
        }

        public Role GetById(int id)
        {
            var entity = _databaseContext.Set<Role>().FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void Remove(Role entity)
        {
            _databaseContext.Attach(entity).State = EntityState.Deleted;
            _databaseContext.SaveChanges();
        }

        public void Update(Role entity)
        {
            _databaseContext.Attach(entity).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
    }
}
