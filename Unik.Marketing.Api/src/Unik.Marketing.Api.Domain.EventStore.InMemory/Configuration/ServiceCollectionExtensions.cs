using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Domain.EventStore.InMemory.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryEventPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IEventPersistence, InMemoryEventPersistence>();

            return services;
        }
    }
}