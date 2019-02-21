using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business
{
    public interface ICommandProcessor
    {
        Task Process(ICommand command);

        Task<TResult> Process<TResult>(ICommand<TResult> command);
    }
}