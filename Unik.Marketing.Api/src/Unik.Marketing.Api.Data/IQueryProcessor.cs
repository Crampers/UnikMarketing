using System.Threading.Tasks;

namespace Unik.Marketing.Api.Data
{
    public interface IQueryProcessor
    {
        Task<TResult> Process<TResult>(IQuery<TResult> query);
    }
}