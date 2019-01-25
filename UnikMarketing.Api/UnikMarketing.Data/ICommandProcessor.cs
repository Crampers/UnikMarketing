using System.Threading.Tasks;

namespace UnikMarketing.Data
{
    public interface ICommandProcessor
    {
        Task Process(ICommand command);
    }
}