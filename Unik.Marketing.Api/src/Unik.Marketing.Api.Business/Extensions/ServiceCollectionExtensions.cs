using Microsoft.Extensions.DependencyInjection;
using Unik.Marketing.Api.Business.Request;
using Unik.Marketing.Api.Business.Request.Handlers;
using Unik.Marketing.Api.Business.User;
using Unik.Marketing.Api.Business.User.Handlers;

namespace Unik.Marketing.Api.Business.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddCommandBus(this IServiceCollection services)
        {
            services.AddSingleton<ICommandBus, CommandBus>();
            
            return services;
        }

        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<CreateRequestCommand, Domain.Request.Request>, CreateRequestCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateNoteCommand, Domain.Request.Request>, UpdateNoteCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteRequestCommand>, DeleteRequestCommandHandler>();
            services.AddTransient<ICommandHandler<CreateUserCommand, Domain.User.User>, CreateUserCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateUserCommand, Domain.User.User>, UpdateUserCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();

            return services;
        }
    }
}
