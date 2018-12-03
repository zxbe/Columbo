﻿using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class RoleType : DictionaryBaseEntity
    {
        public ICollection<Role> Roles { get; private set; }

        public RoleType(int creatorId, string name)
            : base(creatorId, name)
        {
            Roles = new List<Role>();
        }
    }
}
