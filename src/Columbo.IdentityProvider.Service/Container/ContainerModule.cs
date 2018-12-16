using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Columbo.IdentityProvider.Service.Buses;
using Columbo.IdentityProvider.Service.ServiceContracts;
using Columbo.Shared.Api.Command;
using Module = Autofac.Module;

namespace Columbo.IdentityProvider.Service.Container
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.IsClass && x.Name.EndsWith("CommandHandler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register<Func<Type, ICommandHandler>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                    var handler = (ICommandHandler) ctx.Resolve(handlerType);

                    return handler;
                };
            });

            builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
            builder.RegisterType<IdentityProviderService>().As<IIdentityProviderService>();
        }
    }
}