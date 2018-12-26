using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class ApiResource : ManagedBaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<ApiResourceClaim> ApiResourceClaims { get; private set; }
        public ICollection<ClientApiResource> ClientApiResources { get; private set; }
        
        protected ApiResource()
        {
            ApiResourceClaims = new List<ApiResourceClaim>();
            ClientApiResources = new List<ClientApiResource>();
        }

        public ApiResource(int creatorId, string name, string description)
            : base(creatorId)
        {
            Name = name;
            Description = description;

            ApiResourceClaims = new List<ApiResourceClaim>();
            ClientApiResources = new List<ClientApiResource>();
        }
    }
}
