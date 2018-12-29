using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Permission : DictionaryBaseEntity
    {
        public ICollection<RolePermission> RolePermissions { get; private set; }

        protected Permission()
        {
            RolePermissions = new List<RolePermission>();
        }

        public Permission(int id, int creatorId, string name)
            : base(id, creatorId, name)
        {
            RolePermissions = new List<RolePermission>();
        }
    }
}
