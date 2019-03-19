using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Data
{
    public class QueryBus : IQueryProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [DebuggerStepThrough]
        public Task<TResult> Process<TResult>(IQuery<TResult> query)
        {
            var type = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            return Handle(type, query);
        }

        private dynamic Handle(Type type, dynamic request)
        {
            dynamic handler = _serviceProvider.GetService(type);

            return handler.Handle(request);
        }
    }
}