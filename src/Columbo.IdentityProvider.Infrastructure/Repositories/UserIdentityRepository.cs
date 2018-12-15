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
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public UserIdentityRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(UserIdentity entity)
        {
            _databaseContext.Attach(entity).State = EntityState.Added;
            _databaseContext.SaveChanges();
        }

        public void Archive(UserIdentity entity)
        {
            entity.Archive();
            Update(entity);
        }

        public UserIdentity GetById(int id)
        {
            var entity = _databaseContext.Set<UserIdentity>().FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void Update(UserIdentity entity)
        {
            _databaseContext.Attach(entity).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
    }
}
