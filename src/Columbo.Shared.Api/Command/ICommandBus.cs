using Columbo.Shared.Kernel.Interfaces;

namespace Columbo.Shared.Api.Command
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
