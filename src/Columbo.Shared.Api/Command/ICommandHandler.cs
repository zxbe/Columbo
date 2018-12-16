using Columbo.Shared.Kernel.Interfaces;

namespace Columbo.Shared.Api.Command
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
