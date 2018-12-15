using Columbo.Shared.Kernel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.IdentityProvider.Service
{
    public class CommandsBus : ICommandsBus
    {
        private readonly Func<Type, ICommandHandler> _handlersFactory;
        
        public CommandsBus(Func<Type, ICommandHandler> handlersFactory)
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