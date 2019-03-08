using Columbo.Shared.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Sts.Settings
{
    public class CertificateInfo
    {
        public string KeyFilePath { get; set; }
        public string Password { get; set; }
    }

    [AppSettingsSection("Certificates")]
    public class CertificateSettings
    {
        public CertificateInfo IdentityServerCertificate { get; set; }
    }
}
