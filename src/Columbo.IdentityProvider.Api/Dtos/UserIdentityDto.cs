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
    public class UserIdentityDto : ManagedBaseDto
    {
        [ClaimType(ClaimTypes.Login)]
        public string Login { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }

        [ClaimType]
        public UserDto User { get; set; }

        [ClaimType(ClaimTypeTargetEnum.Collection)]
        public ICollection<RoleDto> Roles { get; set; }

        public ICollection<DeviceDto> Devices { get; set; }

        public UserIdentityDto()
        {
            Roles = new List<RoleDto>();
            Devices = new List<DeviceDto>();
        }
    }
}
