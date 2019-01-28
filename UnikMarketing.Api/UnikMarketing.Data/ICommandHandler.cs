using System.Threading.Tasks;

namespace UnikMarketing.Data
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}