﻿using Columbo.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Core.Domain
{
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; private set; }
        public int PermissionId { get; private set; }

        public RolePermission(int creatorId, int roleId, int permissionId)
            : base(creatorId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}