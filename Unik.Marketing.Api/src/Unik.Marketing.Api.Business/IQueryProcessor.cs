using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business
{
    public interface IQueryProcessor
    {
        Task<TResult> Process<TResult>(IQuery<TResult> query);
    }
}