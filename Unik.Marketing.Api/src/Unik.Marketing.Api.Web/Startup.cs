using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Unik.Marketing.Api.Caching.Configuration;
using Unik.Marketing.Api.Caching.InMemory.Configuration;
using Unik.Marketing.Api.Data.Configuration;
using Unik.Marketing.Api.Data.MongoDb.Configuration;
using Unik.Marketing.Api.Domain.Configuration;
using Unik.Marketing.Api.Domain.EventStore.Configuration;
using Unik.Marketing.Api.Domain.EventStore.InMemory.Configuration;
using Unik.Marketing.Api.Messaging.Configuration;

namespace Unik.Marketing.Api.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Info {Title = "Unik.Marketing", Version = "v1"});
            });

            services.AddAggregateRepositories();

            services.AddInMemoryCache();
            services.Configure<CacheOptions>(_configuration.GetSection("Caching"));

            services.AddEventBus();

            services.AddCommandBus();
            services.AddCommandHandlers();

            services.AddQueryBus();
            services.AddMongoDbQueryHandlers();
            services.Configure<MongoDbOptions>(_configuration.GetSection("MongoDb"));

            services.AddEventStore();
            services.AddInMemoryEventPersistence();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(setup => { setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Unik.Marketing v1"); });
        }
    }
}