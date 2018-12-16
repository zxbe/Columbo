using Columbo.Shared.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Columbo.IdentityProvider.Service.Dtos
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int InstanceId { get; set; }
        [DataMember]
        public RoleTypeEnum RoleType { get; set; }
        [DataMember]
        public int CreatorId { get; set; }
        [DataMember]
        public ICollection<PermissionEnum> Permissions { get; set; }

        public RoleDto()
        {
            Permissions = new List<PermissionEnum>();
        }
    }
}