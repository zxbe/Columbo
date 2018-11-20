﻿using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class Permission : DictionaryBaseEntity
    {
        public Permission(int creatorId, string name)
            : base(creatorId, name)
        {
        }
    }
}
