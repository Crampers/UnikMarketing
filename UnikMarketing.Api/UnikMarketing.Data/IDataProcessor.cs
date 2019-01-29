using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UnikMarketing.Data
{
    public interface IDataProcessor
    {
        Task Process(ICommand command);

        Task<TResult> Process<TResult>(ICommand<TResult> command);

        Task<TResult> Process<TResult>(IQuery<TResult> query);
    }
}
