using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Unik.Marketing.Api.Messaging.Configuration
{
    public static class ServiceCollectionExtensions
    {
        private static Type _openEventHandlerInterfaceType = typeof(IEventHandler<>);

        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            AddEventBus(services, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var types = GetConcreteTypes(assemblies.Distinct());
            
            foreach (var type in types)
            {
                foreach (var subscription in GetSubscriptions(type))
                {
                    services.AddTransient(subscription, type);
                }
            }

            AddRequiredServices(services);

            return services;
        }

        private static IEnumerable<Type> GetConcreteTypes(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .SelectMany(x => x.DefinedTypes)
                .Where(x => x.IsClass && !x.IsAbstract);
        }

        private static IEnumerable<Type> GetSubscriptions(Type type)
        {
            return type
                .GetInterfaces()
                .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == _openEventHandlerInterfaceType);
        }

        private static void AddRequiredServices(IServiceCollection services)
        {
            services.TryAddSingleton<IEventBus, EventBus>();
        }
    }
}
