using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Serilog;
using UnikMarketing.Business;
using UnikMarketing.Data;
using UnikMarketing.Data.MongoDb.Request.Commands.Handlers;
using UnikMarketing.Data.MongoDb.Request.Queries.Handlers;
using UnikMarketing.Data.MongoDb.User.Queries.Handlers;
using UnikMarketing.Data.Queries.Request;
using UnikMarketing.Data.Queries.User;
using UnikMarketing.Data.Request.Commands;
using UnikMarketing.Data.Request.Queries;
using UnikMarketing.Domain;

namespace UnikMarketing.Api
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IQueryProcessor, QueryProcessor>(provider => new QueryProcessor(provider));
            services.AddTransient<IQueryHandler<GetRequestByIdQuery, Request>, GetRequestByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetRequestsQuery, ICollection<Request>>, GetRequestsQueryHandler>();
            services.AddTransient<IQueryHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
            services.AddTransient<ICommandHandler<CreateRequestCommand>, CreateRequestCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateRequestCommand>, UpdateRequestCommandHandler>();
            services.AddScoped<IMongoClient>(provider => new MongoClient(_configuration.GetConnectionString("UnikMarketing")));
            services.AddScoped(provider => provider.GetService<IMongoClient>().GetDatabase("unik_marketing"));
            services.AddSingleton<ILogger>(provider =>
            {
                var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(_configuration)
                    .Enrich.WithProperty("GET request", _configuration)
                    .CreateLogger();
                return logger;
            });
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