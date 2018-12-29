using Columbo.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class DeviceType : DictionaryBaseEntity
    {
        public ICollection<Device> Devices { get; private set; }

        protected DeviceType()
        {
            Devices = new List<Device>();
        }

        public DeviceType(int id, int creatorId, string name)
            : base(id, creatorId, name)
        {
            Devices = new List<Device>();
        }
    }
}
