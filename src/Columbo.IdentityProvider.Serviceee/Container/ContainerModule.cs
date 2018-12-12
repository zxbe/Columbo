using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Columbo.IdentityProvider.Service.ServiceContracts;

namespace Columbo.IdentityProvider.Service.Container
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityProviderService>().As<IIdentityProviderService>().InstancePerLifetimeScope();
        }
    }
}