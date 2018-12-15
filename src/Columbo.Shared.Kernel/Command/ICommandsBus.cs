using Columbo.Shared.Kernel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Command
{
    public interface ICommandsBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
