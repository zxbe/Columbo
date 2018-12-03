using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class DeviceType : DictionaryBaseEntity
    {
        public ICollection<Device> Devices { get; private set; }

        public DeviceType(int creatorId, string name)
            : base(creatorId, name)
        {
            Devices = new List<Device>();
        }
    }
}
