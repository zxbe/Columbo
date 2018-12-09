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
        public long IpAddress
        {
            get { return IpAddressObject.Address; }
            set { IpAddressObject = new IPAddress(value); }
        }

        public string MacAddress
        {
            get { return MacAddressObject.ToString(); }
            set { MacAddressObject = new MacAddress(value); }
        }

        public IPAddress IpAddressObject { get; private set; }
        public MacAddress MacAddressObject { get; private set; }
        public bool IsActive { get; private set; }
        public int DeviceTypeId { get; private set; }
        public DeviceType DeviceType { get; private set; }
        public ICollection<UserDevice> UserDevices { get; private set; }

        protected Device()
        {
        }

        public Device(int creatorId, int deviceTypeId, IPAddress ipAddress, MacAddress macAddress)
            : base(creatorId)
        {
            DeviceTypeId = deviceTypeId;
            IpAddressObject = ipAddress;
            MacAddressObject = macAddress;
            IsActive = true;

            UserDevices = new List<UserDevice>();
        }
    }
}
