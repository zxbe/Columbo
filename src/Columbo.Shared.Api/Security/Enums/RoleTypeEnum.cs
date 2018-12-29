using Columbo.Shared.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Columbo.Shared.Api.Security.Enums
{
    public enum RoleTypeEnum
    {
        [Description("Administrator")]
        Administrator = 1,

        [Description("User")]
        User
    }
}
