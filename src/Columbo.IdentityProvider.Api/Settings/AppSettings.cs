using Columbo.Shared.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Settings
{
    [AppSettingsSection("AppSettings")]
    public class AppSettings
    {
        public bool SeedEnable { get; set; }
    }
}
