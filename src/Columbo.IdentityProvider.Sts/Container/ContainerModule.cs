using Autofac;
using Columbo.IdentityProvider.Sts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Sts.Container
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserIdentityService>().As<IUserIdentityService>().InstancePerLifetimeScope();
        }
    }
}
