using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Columbo.IdentityProvider.Service.Dtos
{
    [DataContract]
    public class UserIdentityDto
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public int? PasswordHash { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public UserDto User { get; set; }
        [DataMember]
        public ICollection<RoleDto> Roles { get; set; }
        [DataMember]
        public ICollection<DeviceDto> Devices { get; set; }

        public UserIdentityDto()
        {
            Roles = new List<RoleDto>();
            Devices = new List<DeviceDto>();
        }
    }
}