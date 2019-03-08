using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Business.Domain.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAggregateRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
