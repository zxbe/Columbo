using Columbo.Shared.Api.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class RolePermissionDto
    {
        public int RoleId { get; set; }
        public PermissionEnum Permission { get; set; }
    }
}
