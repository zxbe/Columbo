using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class ClientApiResource : BaseEntity
    {
        public int ClientId { get; private set; }
        public int ApiResourceId { get; private set; }
        public Client Client { get; private set; }
        public ApiResource ApiResource { get; private set; }

        protected ClientApiResource()
        {
        }

        public ClientApiResource(int creatorId, int clientId, int apiResourceId)
            : base(creatorId)
        {
            ClientId = clientId;
            ApiResourceId = apiResourceId;
        }
    }
}
