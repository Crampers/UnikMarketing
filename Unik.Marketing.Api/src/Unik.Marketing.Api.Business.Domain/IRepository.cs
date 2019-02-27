using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business.Domain
{
    public interface IRepository<TAggregate>
        where TAggregate : AggregateRoot
    {
        Task Save(TAggregate aggregate);

        Task<TAggregate> Get(Guid id);
    }
}
