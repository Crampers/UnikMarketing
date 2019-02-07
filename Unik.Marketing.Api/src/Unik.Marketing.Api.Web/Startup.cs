using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Unik.Marketing.Api.Business;
using Unik.Marketing.Api.Data;
using Unik.Marketing.Api.Data.MongoDb.Request.Commands.Handlers;
using Unik.Marketing.Api.Data.MongoDb.Request.Queries.Handlers;
using Unik.Marketing.Api.Data.MongoDb.User.Commands;
using Unik.Marketing.Api.Data.MongoDb.User.Queries.Handlers;
using Unik.Marketing.Api.Data.Request.Commands;
using Unik.Marketing.Api.Data.Request.Queries;
using Unik.Marketing.Api.Data.User.Commands;
using Unik.Marketing.Api.Data.User.Queries;
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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddScoped<IDataProcessor, DataProcessor>();
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
        }
    }
}