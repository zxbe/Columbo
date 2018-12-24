using Columbo.IdentityProvider.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Dtos
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public bool IsActive { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
        public int CreatorId { get; set; }
    }
}
