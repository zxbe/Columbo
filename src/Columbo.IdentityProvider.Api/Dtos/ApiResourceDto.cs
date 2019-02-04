using Columbo.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class ApiResourceDto : ManagedBaseDto
    {
        public Guid ApiGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InstanceId { get; set; }
        public ICollection<string> ClaimTypes { get; set; }

        public ApiResourceDto()
        {
            ClaimTypes = new List<string>();
        }
    }
}
