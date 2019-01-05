using Columbo.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class InstanceDto : ManagedBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
