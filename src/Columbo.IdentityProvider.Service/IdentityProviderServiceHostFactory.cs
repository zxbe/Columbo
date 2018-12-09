using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using Autofac;
using Columbo.IdentityProvider.Service.ServiceContracts;
using Columbo.IdentityProvider.Service.Startup;
using Columbo.Shared.Infrastructure;

namespace Columbo.IdentityProvider.Service
{
    public class IdentityProviderServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = ContainerConfig.Create();

            using (var scope = container.BeginLifetimeScope())
            {
                var dbContext = scope.Resolve<IDatabaseContext>();
                DatabaseConfig.Initialing(dbContext);

                var service = scope.Resolve<IIdentityProviderService>();

                var serviceHost = new ServiceHost(service, baseAddresses);

                return serviceHost;
            }
        }
    }
}