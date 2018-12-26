using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class IdentityResourceClaim : BaseEntity
    {
        public int IdentityResourceId { get; private set; }
        public int ClaimTypeId { get; private set; }
        public IdentityResource IdentityResource { get; private set; }
        public ClaimType ClaimType { get; private set; }

        protected IdentityResourceClaim()
        {
        }

        public IdentityResourceClaim(int creatorId, int identityResourceId, int claimTypeId)
            : base(creatorId)
        {
            IdentityResourceId = identityResourceId;
            ClaimTypeId = claimTypeId;
        }
    }
}
