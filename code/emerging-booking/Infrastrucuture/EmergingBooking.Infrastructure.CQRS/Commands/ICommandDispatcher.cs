using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Commands
{
    public interface ICommandDispatcher
    {
        Task<CommandResult> ExecuteAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}