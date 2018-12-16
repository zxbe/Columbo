using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        void Remove(Role entity);
    }
}
