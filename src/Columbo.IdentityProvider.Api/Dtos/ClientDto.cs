using Columbo.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class ClientDto : ManagedBaseDto
    {
        public Guid ClientGuid { get; set; }
        public string SecretHash { get; set; }
        public string RedirectUri { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int SqurityCodeLifetime { get; set; }
        public bool IsActive { get; set; }
    }
}
