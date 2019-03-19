using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Domain.EventStore.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventStore(this IServiceCollection services)
        {
            services.AddSingleton<IEventStore, EventStore>();

            return services;
        }
    }
}