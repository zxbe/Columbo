using System;
using System.Collections.Generic;
using System.Text;
using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Kernel;
using Columbo.Shared.Kernel.Interfaces;

namespace Columbo.IdentityProvider.Core.Repositories
{
    public interface IUserIdentityRepository : IRepository<UserIdentity>
    {
        void Archive(UserIdentity entity);
    }
}
