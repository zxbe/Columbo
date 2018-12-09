using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace Columbo.IdentityProvider.Service.Startup
{
    public static class ContainerConfig
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<Columbo.IdentityProvider.Infrastructure.Container.ContainerModule>();
            builder.RegisterModule<Columbo.IdentityProvider.Service.Container.ContainerModule>();

            return builder.Build();
        }
    }
}