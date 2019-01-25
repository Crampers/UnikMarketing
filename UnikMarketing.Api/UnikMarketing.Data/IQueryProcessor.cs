using System.Threading.Tasks;

namespace UnikMarketing.Data
{
    public interface IQueryProcessor
    {
        Task<TResult> Process<TResult>(IQuery<TResult> query);
    }
}