using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class ApiResourceClaim : BaseEntity
    {
        public int ApiResourceId { get; private set; }
        public int ClaimTypeId { get; private set; }
        public ApiResource ApiResource { get; private set; }
        public ClaimType ClaimType { get; private set; }

        protected ApiResourceClaim()
        {
        }

        public ApiResourceClaim(int creatorId, int apiResourceId, int claimTypeId)
            : base(creatorId)
        {
            ApiResourceId = apiResourceId;
            ClaimTypeId = claimTypeId;
        }
    }
}
