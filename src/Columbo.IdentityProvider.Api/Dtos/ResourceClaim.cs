using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class ResourceClaim
    {
        public int ResourceId { get; set; }
        public string ClaimType { get; set; }
    }
}
