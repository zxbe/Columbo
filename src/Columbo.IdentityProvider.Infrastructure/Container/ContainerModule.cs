using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Columbo.IdentityProvider.Core.Repositories;
using Columbo.IdentityProvider.Infrastructure.Repositories;
using Columbo.Shared.Infrastructure;

namespace Columbo.IdentityProvider.Infrastructure.Container
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().InstancePerLifetimeScope();
            builder.RegisterType<UserIdentityRepository>().As<IUserIdentityRepository>().InstancePerLifetimeScope();
        }
    }
}
