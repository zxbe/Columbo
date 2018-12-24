using Columbo.Shared.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstanceId { get; set; }
        public RoleTypeEnum RoleType { get; set; }
        public int CreatorId { get; set; }
        public ICollection<PermissionEnum> Permissions { get; set; }

        public RoleDto()
        {
            Permissions = new List<PermissionEnum>();
        }
    }
}
