using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Columbo.Shared.Infrastructure;

namespace Columbo.IdentityProvider.Infrastructure.Container
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseInitializer>().As<IDatabaseInitializer>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().InstancePerLifetimeScope();
        }
    }
}
