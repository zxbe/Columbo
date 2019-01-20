using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Client : AggregateRoot
    {
        public Guid ClientGuid { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string SecretHash { get; private set; }
        public Uri RedirectUri { get; private set; }
        public Uri PostLogoutRedirectUri { get; private set; }
        public int IdentityTokenLifetime { get; private set; } //sec
        public int AccessTokenLifetime { get; private set; }
        public int SequrityCodeLifetiem { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<ClientApiResource> ClientApiResources { get; private set; }
        public ICollection<ClientIdentityResource> ClientIdentityResources { get; private set; }
        public ICollection<SequrityCode> SequrityCodes { get; private set; }

        protected Client()
        {
            ClientApiResources = new List<ClientApiResource>();
            ClientIdentityResources = new List<ClientIdentityResource>();
            SequrityCodes = new List<SequrityCode>();
        }

        public Client(
            int creatorId, 
            Guid clientGuid,
            string name,
            string description,
            string secretHash, 
            Uri redirectUri, 
            Uri postLogoutRedirectUri,
            int identityTokenLifetime,
            int accessTokenLifetime,
            int sequrityCodeLifetime)
            : base(creatorId)
        {
            ClientGuid = clientGuid;
            Name = name;
            Description = description;
            SecretHash = secretHash;
            RedirectUri = redirectUri;
            PostLogoutRedirectUri = postLogoutRedirectUri;
            IdentityTokenLifetime = identityTokenLifetime;
            AccessTokenLifetime = accessTokenLifetime;
            SequrityCodeLifetiem = sequrityCodeLifetime;
            IsActive = true;
            
            ClientApiResources = new List<ClientApiResource>();
            ClientIdentityResources = new List<ClientIdentityResource>();
            SequrityCodes = new List<SequrityCode>();
        }

        public void AddIdentityResources(List<int> identityResourcesId, int creatorId)
        {
            identityResourcesId.ForEach(x => ClientIdentityResources.Add(new ClientIdentityResource(1, this.Id, x)));
        }
    }
}
