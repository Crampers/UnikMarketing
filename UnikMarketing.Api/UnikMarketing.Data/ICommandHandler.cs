using System.Threading.Tasks;

namespace UnikMarketing.Data
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}