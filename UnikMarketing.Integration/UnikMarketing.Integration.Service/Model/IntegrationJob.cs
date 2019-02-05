using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using UnikMarketing.Integration.Tools;

namespace UnikMarketing.Integration.Service
{
    internal class IntegrationJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var connectionString = context.MergedJobDataMap.Get("ConnectionString") as string;

            //TODO: Writer
            return Task.Run(() =>
            {
                var json = SequelToJson.GetJson(connectionString);
                //var sometool = WriteJsonToMongoDb;  
            });
        }
    }
}
