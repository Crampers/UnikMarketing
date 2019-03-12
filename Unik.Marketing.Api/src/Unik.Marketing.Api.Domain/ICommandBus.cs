using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain
{
    public interface ICommandBus
    {
        Task Process(ICommand command);

        Task<TResult> Process<TResult>(ICommand<TResult> command);
    }
}