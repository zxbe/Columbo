﻿using Columbo.Shared.Kernel.Domain;
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

        public DeviceType(int creatorId, string name)
            : base(creatorId, name)
        {
            Devices = new List<Device>();
        }
    }
}
