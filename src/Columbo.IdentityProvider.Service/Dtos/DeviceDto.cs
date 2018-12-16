using Columbo.IdentityProvider.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Columbo.IdentityProvider.Service.Dtos
{
    [DataContract]
    public class DeviceDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IpAddress { get; set; }
        [DataMember]
        public string MacAddress { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DeviceTypeEnum DeviceType { get; set; }
        [DataMember]
        public int CreatorId { get; set; }
    }
}