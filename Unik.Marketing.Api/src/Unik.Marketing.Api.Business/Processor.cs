using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Business
{
    public class Processor : ICommandProcessor, IQueryProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public Processor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [DebuggerStepThrough]
        public Task Process(ICommand command)
        {
            var type = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            return Handle(type, command);
        }

        [DebuggerStepThrough]
        public Task<TResult> Process<TResult>(ICommand<TResult> command)
        {
            var type = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            return Handle(type, command);
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