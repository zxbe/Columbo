using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class ClientIdentityResource : BaseEntity
    {
        public int ClientId { get; private set; }
        public int IdentityResourceId { get; private set; }
        public Client Client { get; private set; }
        public IdentityResource IdentityResource { get; private set; }

        protected ClientIdentityResource()
        {
        }

        public ClientIdentityResource(int creatorId, int clientId, int identityResourceId)
            : base(creatorId)
        {
            ClientId = clientId;
            IdentityResourceId = identityResourceId;
        }
    }
}
