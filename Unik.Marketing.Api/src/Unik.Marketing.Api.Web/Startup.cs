using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using Unik.Marketing.Api.Business;
using Unik.Marketing.Api.Business.Domain;
using Unik.Marketing.Api.Business.Domain.Request;
using Unik.Marketing.Api.Business.Domain.User;
using Unik.Marketing.Api.Business.EventStore;
using Unik.Marketing.Api.Business.EventStore.InMemory;
using Unik.Marketing.Api.Business.Request;
using Unik.Marketing.Api.Business.Request.Handlers;
using Unik.Marketing.Api.Business.User;
using Unik.Marketing.Api.Business.User.Handlers;
using Unik.Marketing.Api.Data;
using Unik.Marketing.Api.Data.MongoDb.Request.Queries.Handlers;
using Unik.Marketing.Api.Data.MongoDb.User.Queries.Handlers;
using Unik.Marketing.Api.Data.Request.Queries;
using Unik.Marketing.Api.Data.User.Queries;

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
                setup.SwaggerDoc("v1", new Info { Title = "Unik.Marketing", Version = "v1" });
            });
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryProcessor, QueryBus>();
            services.AddTransient<IQueryHandler<GetRequestsQuery, ICollection<Data.Request.Request>>, GetRequestsQueryHandler>();
            services.AddTransient<IQueryHandler<GetUsersQuery, ICollection<Data.User.User>>, GetUsersQueryHandler>();
            services.AddTransient<ICommandHandler<CreateRequestCommand, Request>, CreateRequestCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateNoteCommand, Request>, UpdateNoteCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteRequestCommand>, DeleteRequestCommandHandler>();
            services.AddTransient<ICommandHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateUserCommand, User>, UpdateUserCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
            services.AddScoped<IMongoClient>(provider => new MongoClient(_configuration.GetConnectionString("UnikMarketing")));
            services.AddScoped(provider => provider.GetService<IMongoClient>().GetDatabase("unik_marketing"));
            services.AddSingleton<IEventStore, EventStore>();
            services.AddSingleton<IEventPersistence, InMemoryEventPersistence>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
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
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Unik.Marketing v1");
            });
        }
    }
}