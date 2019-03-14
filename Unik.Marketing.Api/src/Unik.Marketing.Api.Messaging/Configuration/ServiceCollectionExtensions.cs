using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Messaging.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, EventBus>();

            return services;
        }
    }
}
