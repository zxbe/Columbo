using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class RoleType : DictionaryBaseEntity
    {
        public ICollection<Role> Roles { get; private set; }

        protected RoleType()
        {
            Roles = new List<Role>();
        }

        public RoleType(int id, int creatorId, string name)
            : base(id, creatorId, name)
        {
            Roles = new List<Role>();
        }
    }
}
