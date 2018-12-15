using Columbo.Shared.Kernel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Kernel.Command
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
