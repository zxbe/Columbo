using Columbo.Shared.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Columbo.Shared.Api.Security.Enums
{
    public enum PermissionEnum
    {
        [Description("Operations on user identity")]
        OperationsOnUserIdentity = 1,

        [Description("Operations on user device")]
        OperationsOnUserDevice,

        [Description("Operations on user")]
        OperationsOnUser,

        [Description("Operations on client")]
        OperationsOnClient
    }
}
