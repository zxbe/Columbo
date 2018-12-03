using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Device : ManagedBaseEntity
    {
        public IPAddress IpAddress { get; private set; }
        public string MacAddress { get; private set; } //TODO create data value type
        public bool IsActive { get; private set; }
        public int DeviceTypeId { get; private set; }
        public DeviceType DeviceType { get; private set; }
        
        public Device(int creatorId, int deviceTypeId, IPAddress ipAddress, string macAddress)
            : base(creatorId)
        {
            DeviceTypeId = deviceTypeId;
            IpAddress = IpAddress;
            MacAddress = macAddress;
            IsActive = true;
        }
    }
}
