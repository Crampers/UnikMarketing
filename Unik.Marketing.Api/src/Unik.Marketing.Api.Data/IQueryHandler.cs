using System.Threading.Tasks;

namespace Unik.Marketing.Api.Data
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}