using Columbo.Shared.Kernel.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
