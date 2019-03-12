using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Caching.InMemory.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryCache(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICache<,>), typeof(InMemoryCache<,>));

            return services;
        }
    }
}
