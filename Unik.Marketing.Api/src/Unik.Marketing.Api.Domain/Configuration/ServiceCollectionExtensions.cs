using Microsoft.Extensions.DependencyInjection;
using Unik.Marketing.Api.Domain.Request.Commands;
using Unik.Marketing.Api.Domain.Request.Commands.Handlers;
using Unik.Marketing.Api.Domain.User.Commands;
using Unik.Marketing.Api.Domain.User.Commands.Handlers;

namespace Unik.Marketing.Api.Domain.Configuration
{
    public static class ServiceCollectionExtensions
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

        public static IServiceCollection AddAggregateRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
