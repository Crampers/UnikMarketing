using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using UnikMarketing.Business;
using UnikMarketing.Data;
using UnikMarketing.Data.MongoDb.Request.Commands.Handlers;
using UnikMarketing.Data.MongoDb.Request.Queries.Handlers;
using UnikMarketing.Data.MongoDb.User.Commands;
using UnikMarketing.Data.MongoDb.User.Queries.Handlers;
using UnikMarketing.Data.Request.Commands;
using UnikMarketing.Data.Request.Queries;
using UnikMarketing.Data.User.Commands;
using UnikMarketing.Data.User.Queries;
using UnikMarketing.Domain;

namespace UnikMarketing.Api
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