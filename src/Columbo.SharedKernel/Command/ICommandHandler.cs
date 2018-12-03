using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.SharedKernel.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command); //todo return result
    }
}
