using Columbo.Shared.Kernel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Command
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
