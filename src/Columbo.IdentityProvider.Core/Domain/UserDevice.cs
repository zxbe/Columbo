﻿using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class UserDevice : ManagedBaseEntity
    {
        public int UserIdentityId { get; private set; }
        public int DeviceId { get; private set; }
        public bool IsCodeRequired { get; private set; }

        public UserDevice(int creatorId, int userIdentityId, int deviceId, bool isCodeRequired)
            : base(creatorId)
        {
            UserIdentityId = userIdentityId;
            DeviceId = deviceId;
            IsCodeRequired = isCodeRequired;
        }
    }
}