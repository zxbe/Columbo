using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Instance : ManagedBaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Role> Roles { get; private set; }
        public ICollection<ApiResource> ApiResources { get; private set; }

        protected Instance()
        {
            Roles = new List<Role>();
            ApiResources = new List<ApiResource>();
        }

        public Instance(int creatorId, string name, string description)
            : base(creatorId)
        {
            Name = name;
            Description = description;

            Roles = new List<Role>();
            ApiResources = new List<ApiResource>();
        }
    }
}
