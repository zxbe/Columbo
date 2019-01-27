using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Sts.Extensions
{
    public static class IdentityServerBuilderExtension
    {
        public static IIdentityServerBuilder AddCertificate(this IIdentityServerBuilder identityServerBuilder)
        {
            X509Certificate2 certificate = null;
            using (var certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                certStore.Open(OpenFlags.ReadOnly);

                var certCollection = certStore.Certificates.Find(
                    X509FindType.FindBySubjectName,
                    "Columbo.IdentityProvider.Sts",
                    false);

                if (certCollection.Count == 1)
                {
                    certificate = certCollection[0];
                }
            }

            if (certificate == null)
                throw new Exception(); // todo exception

            identityServerBuilder.AddSigningCredential(certificate);

            return identityServerBuilder;
        }
    }
}
