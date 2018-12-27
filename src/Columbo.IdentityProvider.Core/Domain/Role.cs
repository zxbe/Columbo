using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Role : ManagedBaseEntity
    {
        public string Name { get; private set; }
        public int InstanceId { get; private set; }
        public int RoleTypeId { get; private set; }
        public Instance Instance { get; private set; }
        public RoleType RoleType { get; private set; }
        public ICollection<RolePermission> RolePermissions { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }

        protected Role()
        {
            RolePermissions = new List<RolePermission>();
            UserRoles = new List<UserRole>();
        }

        public Role(int creatorId, string name, int instanceId, int roleTypeId)
            : base(creatorId)
        {
            Name = name;
            InstanceId = instanceId;
            RoleTypeId = roleTypeId;

            RolePermissions = new List<RolePermission>();
            UserRoles = new List<UserRole>();
        }

        public void AddPermissions(List<int> permissionsId, int creatorId)
        {
            permissionsId.ForEach(x => RolePermissions.Add(new RolePermission(creatorId, this.Id, x)));
        }
    }
}
