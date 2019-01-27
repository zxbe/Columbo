using Columbo.Shared.Api.Dtos;
using Columbo.Shared.Api.Security;
using Columbo.Shared.Api.Security.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class UserDto : ManagedBaseDto
    {
        [ClaimType(ClaimTypes.Name)]
        public string Name { get; set; }

        [ClaimType(ClaimTypes.Surname)]
        public string Surname { get; set; }

        [ClaimType(ClaimTypes.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
