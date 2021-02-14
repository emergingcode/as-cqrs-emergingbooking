using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task<CommandResult> ExecuteAsync(TCommand command);
    }
}
