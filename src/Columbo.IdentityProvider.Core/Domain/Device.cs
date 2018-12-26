using Columbo.Shared.Kernel.ValueObjects;
using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

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

        protected Device()
        {
            UserDevices = new List<UserDevice>();
        }

        public Device(int creatorId, int deviceTypeId, IPAddress ipAddress, MacAddress macAddress)
            : base(creatorId)
        {
            DeviceTypeId = deviceTypeId;
            IpAddress = ipAddress;
            MacAddress = macAddress;
            IsActive = true;

            UserDevices = new List<UserDevice>();
        }
    }
}
