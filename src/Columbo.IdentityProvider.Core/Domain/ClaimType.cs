using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class ClaimType : DictionaryBaseEntity
    {
        public string Type { get; private set; }
        public ICollection<ApiResourceClaim> ApiResourceClaims { get; private set; }
        public ICollection<IdentityResourceClaim> IdentityResourceClaims { get; private set; }

        protected ClaimType()
        {
            ApiResourceClaims = new List<ApiResourceClaim>();
            IdentityResourceClaims = new List<IdentityResourceClaim>();
        }

        public ClaimType(int creatorId, string name, string type)
            : base(creatorId, name)
        {
            Type = type;
            ApiResourceClaims = new List<ApiResourceClaim>();
            IdentityResourceClaims = new List<IdentityResourceClaim>();
        }
    }
}
