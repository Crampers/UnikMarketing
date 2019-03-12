using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public Task Process(ICommand command)
        {
            var type = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            return Handle(type, command);
        }
        
        public Task<TResult> Process<TResult>(ICommand<TResult> command)
        {
            var type = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            return Handle(type, command);
        }

        private dynamic Handle(Type type, dynamic request)
        {
            dynamic handler = _serviceProvider.GetService(type);

            return handler.Handle(request);
        }
    }
}