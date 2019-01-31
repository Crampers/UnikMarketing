using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using KonvToolbox;
using Quartz;
using Quartz.Impl;
using Serilog;

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

                _cron = CreateCronTab(ReadConfiguration(configurationPath)).Result;
            }
            catch (Exception e)
            {
                _logger?.Fatal(e, "Failed to initialize export service");
                EventLogHandler.WriteToEventLog(WinApiHelper.FlattenException(e), EventLogEntryType.Error);
            }
        }
        private static ILogger CreateLogger()
        {
            return new LoggerConfiguration().CreateLogger();
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

        private ICollection<Job> ReadConfiguration(string configurationPath)
        {
            if (configurationPath == null)
            {
                _logger?.Fatal("No export configuration file path specified in application settings");

                throw new Exception("Invalid application configuration");
            }

            if (!File.Exists(configurationPath))
            {
                _logger?.Fatal("Export configuration file not found at path \"{ConfigurationPath}\"", configurationPath);

                throw new Exception("Invalid application configuration");
            }

            return ConfigurationManager.GetSection(configurationPath, _logger);
        }

        private async Task<IScheduler> CreateCronTab(ICollection<Job> jobs)
        {
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();

            _logger?.Information("Setting up scheduler");

            foreach (var job in jobs)
                try
                {
                    await scheduler.ScheduleJob(
                        JobBuilder
                            .Create<DynamicJob>()
                            .UsingJobData(new JobDataMap
                            {
                                {"action", new Func<Task>(job.Run)}
                            })
                            .Build(),
                        TriggerBuilder.Create()
                            .WithCronSchedule(job.CronExpression, s => s.Build())
                            .Build()
                    );
                }
                catch (FormatException)
                {
                    _logger?.Error(
                        "Job \"{Name}\" was configured with an invalid cron expression (\"{CronExpression}\") and was skipped",
                        job.Name,
                        job.CronExpression
                    );
                }

            _logger?.Information("Finished setting up scheduler");

            return scheduler;
        }

    }
}
