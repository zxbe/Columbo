using Columbo.Shared.Api.Command;
using Columbo.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Columbo.IdentityProvider.Api.Buses
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, ICommandHandler> _handlersFactory;

        public CommandBus(Func<Type, ICommandHandler> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = (ICommandHandler<TCommand>)_handlersFactory(typeof(TCommand));
            commandHandler.Handle(command);
        }
    }
}
