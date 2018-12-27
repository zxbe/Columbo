﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class UserIdentityDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int? PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public UserDto User { get; set; }
        public int CreatorId { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
        public ICollection<DeviceDto> Devices { get; set; }

        public UserIdentityDto()
        {
            Roles = new List<RoleDto>();
            Devices = new List<DeviceDto>();
        }
    }
}