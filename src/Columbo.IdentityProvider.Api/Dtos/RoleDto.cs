using Columbo.Shared.Api.Dtos;
using Columbo.Shared.Api.Security;
using Columbo.Shared.Api.Security.Attributes;
using Columbo.Shared.Api.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class RoleDto : ManagedBaseDto
    {
        public string Name { get; set; }

        public int? InstanceId { get; set; }

        [ClaimType(ClaimTypes.RoleTypeId)]
        public RoleTypeEnum RoleType { get; set; }

        [ClaimType(ClaimTypes.PermissionId, ClaimTypeTargetEnum.EnumCollection)]
        public ICollection<PermissionEnum> Permissions { get; set; }

        public RoleDto()
        {
            Permissions = new List<PermissionEnum>();
        }
    }
}
