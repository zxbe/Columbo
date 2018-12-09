using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class UserRole : BaseEntity
    {
        public int UserIdentityId { get; private set; }
        public int RoleId { get; private set; }
        public UserIdentity UserIdentity { get; private set; }
        public Role Role { get; private set; }

        protected UserRole()
        {
        }

        public UserRole(int creatorId, int userIdentityId, int roleId)
            : base(creatorId)
        {
            UserIdentityId = userIdentityId;
            RoleId = roleId;
        }
    }
}
