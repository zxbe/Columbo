using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Instance : DictionaryBaseEntity
    {
        public ICollection<Role> Roles { get; private set; }
        public ICollection<ApiResource> ApiResources { get; private set; }

        protected Instance()
        {
            Roles = new List<Role>();
            ApiResources = new List<ApiResource>();
        }

        public Instance(int creatorId, string name)
            : base(creatorId, name)
        {
            Roles = new List<Role>();
            ApiResources = new List<ApiResource>();
        }
    }
}
