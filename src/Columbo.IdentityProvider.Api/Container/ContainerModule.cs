using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Columbo.IdentityProvider.Api.Buses;
using Columbo.Shared.Api.Command;

namespace Columbo.IdentityProvider.Api.Container
{
    public class ContainerModule : Autofac.Module
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
                    var handler = (ICommandHandler)ctx.Resolve(handlerType);

                    return handler;
                };
            });

            builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
        }
    }
}
