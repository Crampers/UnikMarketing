﻿using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Unik.Marketing.Api.Data.MongoDb.Request.Events;
using Unik.Marketing.Api.Data.MongoDb.Request.Queries.Handlers;
using Unik.Marketing.Api.Data.MongoDb.User.Queries.Handlers;
using Unik.Marketing.Api.Data.Request.Queries;
using Unik.Marketing.Api.Data.User.Queries;
using Unik.Marketing.Api.Domain.Request.Events;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Data.MongoDb.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbQueryHandlers(this IServiceCollection services)
        {
            services.AddScoped<IMongoClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<MongoDbOptions>>().Value;

                return new MongoClient(options.ConnectionString);
            });
            services.AddScoped(provider => provider.GetService<IMongoClient>().GetDatabase("unik_marketing"));
            services
                .AddTransient<IQueryHandler<GetRequestsQuery, ICollection<Data.Request.Request>>,
                    GetRequestsQueryHandler>();
            services.AddTransient<IQueryHandler<GetUsersQuery, ICollection<Data.User.User>>, GetUsersQueryHandler>();

            return services;
        }

        public static IServiceCollection AddMongoDbViewHandlers(this IServiceCollection services)
        {
            services.AddTransient<IEventHandler<RequestCreatedEvent>, RequestCreatedViewHandler>();
            services.AddTransient<IEventHandler<NoteUpdatedEvent>, NoteUpdatedViewHandler>();

            return services;
        }
    }
}