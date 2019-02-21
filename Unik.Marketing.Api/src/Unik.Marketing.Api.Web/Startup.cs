using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using Unik.Marketing.Api.Business;
using Unik.Marketing.Api.Business.Request.Commands;
using Unik.Marketing.Api.Business.Request.Commands.Handlers;
using Unik.Marketing.Api.Business.Request.Queries;
using Unik.Marketing.Api.Business.Request.Queries.Handlers;
using Unik.Marketing.Api.Business.User.Commands;
using Unik.Marketing.Api.Business.User.Commands.Handlers;
using Unik.Marketing.Api.Business.User.Queries;
using Unik.Marketing.Api.Business.User.Queries.Handlers;
using Unik.Marketing.Api.Domain;

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
            services.AddScoped<ICommandProcessor, Processor>();
            services.AddScoped<IQueryProcessor, Processor>();
            services.AddTransient<IQueryHandler<GetRequestsQuery, ICollection<Request>>, GetRequestsQueryHandler>();
            services.AddTransient<IQueryHandler<GetUsersQuery, ICollection<User>>, GetUsersQueryHandler>();
            services.AddTransient<ICommandHandler<CreateRequestCommand, Request>, CreateRequestCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateRequestCommand, Request>, UpdateRequestCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteRequestCommand>, DeleteRequestCommandHandler>();
            services.AddTransient<ICommandHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateUserCommand, User>, UpdateUserCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
            services.AddScoped<IMongoClient>(provider => new MongoClient(_configuration.GetConnectionString("UnikMarketing")));
            services.AddScoped(provider => provider.GetService<IMongoClient>().GetDatabase("unik_marketing"));
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