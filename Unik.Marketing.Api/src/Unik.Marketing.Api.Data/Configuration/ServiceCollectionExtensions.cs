using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Data.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQueryBus(this IServiceCollection services)
        {
            services.AddScoped<IQueryProcessor, QueryBus>();

            return services;
        }
    }
}