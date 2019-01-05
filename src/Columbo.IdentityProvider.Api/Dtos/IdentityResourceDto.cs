using Columbo.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class IdentityResourceDto : ManagedBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public ICollection<string> ClaimTypes { get; set; }

        public IdentityResourceDto()
        {
            ClaimTypes = new List<string>();
        }
    }
}
