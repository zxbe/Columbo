using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class IdentityResource : ManagedBaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool ShowInDiscoveryDocument { get; private set; }
        public ICollection<IdentityResourceClaim> IdentityResourceClaims { get; private set; }
        public ICollection<ClientIdentityResource> ClientIdentityResources { get; private set; }
        
        protected IdentityResource()
        {
            IdentityResourceClaims = new List<IdentityResourceClaim>();
            ClientIdentityResources = new List<ClientIdentityResource>();
        }

        public IdentityResource(int creatorId, string name, string description, bool showInDiscoveryDocument = true)
            : base(creatorId)
        {
            Name = name;
            Description = description;
            ShowInDiscoveryDocument = showInDiscoveryDocument;

            IdentityResourceClaims = new List<IdentityResourceClaim>();
            ClientIdentityResources = new List<ClientIdentityResource>();
        }
    }
}
