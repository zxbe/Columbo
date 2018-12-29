using Columbo.Shared.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Enums
{
    public enum DeviceTypeEnum
    {
        [Description("Computer")]
        Computer = 1,

        [Description("Mobile phone")]
        MobilePhone
    }
}
