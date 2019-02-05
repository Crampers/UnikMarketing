using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using KonvToolbox;
using Quartz;
using Quartz.Impl;
using Serilog;
using UnikMarketing.Integration.Service.Model;
using UnikMarketing.Integration.Tools;

namespace UnikMarketing.Integration.Service
{
    public partial class UmIntegrationService : ServiceBase
    {
        private readonly IScheduler _cron;
        private readonly ILogger _logger;

        public UmIntegrationService()
        {
            try
            {
                InitializeComponent();

                _logger = CreateLogger();

                _logger?.Information("Initializing service");

                var configurationPath = ConfigurationManager.AppSettings["configuration"];

                if (string.IsNullOrWhiteSpace(configurationPath))
                    _logger?.Fatal("Configuration file not found at \"{ConfigurationPath}\"", configurationPath);

                _cron = SimonSays(ReadSimon());
            }
            catch (Exception e)
            {
                _logger?.Fatal(e, "Failed to initialize export service");
                EventLogHandler.WriteToEventLog(WinApiHelper.FlattenException(e), EventLogEntryType.Error);
            }
        }

        private Simon ReadSimon()
        {
            return new Simon(
                ConfigurationManager.ConnectionStrings["UnikBoligCon"].ConnectionString,
                ConfigurationManager.AppSettings["CronScheduleExpression"],
                (string) ConfigurationManager.GetSection("Destination"));
        }

        private static ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
        }

        protected override async void OnStart(string[] args)
        {
            _logger?.Information("Starting scheduler");
            await _cron.Start();
            _logger?.Information("Started scheduler");
        }

        protected override async void OnStop()
        {
            _logger?.Information("Stopping scheduler");
            await _cron.Shutdown();
            _logger?.Information("Stopped scheduler");
        }

        private IScheduler SimonSays(Simon simon)
        {
            var factory = new StdSchedulerFactory();
            var scheduler = factory.GetScheduler().Result;

            _logger?.Information("Setting up scheduler");

            try
            {
                scheduler.ScheduleJob(
                    JobBuilder
                        .Create<IntegrationJob>()
                        .UsingJobData(new JobDataMap
                        {
                            {"ConnectionString", simon.ConnectionString}
                        })
                        .Build(),
                    TriggerBuilder.Create()
                        .WithCronSchedule(simon.CronScheduleExpression, s => s.Build())
                        .Build()
                ).Wait();
            }
            catch (FormatException)
            {
                _logger?.Error(
                    "Simon \"{Destination}\" was configured with an invalid cron expression (\"{CronScheduleExpression}\") and was skipped",
                    simon.Destination,
                    simon.CronScheduleExpression
                );
            }

            _logger?.Information("Finished setting up scheduler");

            return scheduler;
        }
    }
}