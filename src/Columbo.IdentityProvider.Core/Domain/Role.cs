using Columbo.SharedKernel.Domain;
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
        
        public Role(int creatorId, string name, int instanceId, int roleTypeId)
            : base(creatorId)
        {
            Name = name;
            InstanceId = instanceId;
            RoleTypeId = roleTypeId;
        }
    }
}
