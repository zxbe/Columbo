using Columbo.IdentityProvider.Core.ValueObjects;
using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Device : ManagedBaseEntity
    {
        public IPAddress IpAddress { get; private set; }
        public MacAddress MacAddress { get; private set; }
        public bool IsActive { get; private set; }
        public int DeviceTypeId { get; private set; }
        public DeviceType DeviceType { get; private set; }
        public ICollection<UserDevice> UserDevices { get; private set; }
        
        public Device(int creatorId, int deviceTypeId, IPAddress ipAddress, MacAddress macAddress)
            : base(creatorId)
        {
            DeviceTypeId = deviceTypeId;
            IpAddress = IpAddress;
            MacAddress = macAddress;
            IsActive = true;

            UserDevices = new List<UserDevice>();
        }
    }
}
