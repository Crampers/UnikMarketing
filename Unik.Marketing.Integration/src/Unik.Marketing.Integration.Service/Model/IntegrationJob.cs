using System.Threading.Tasks;
using Quartz;
using Unik.Marketing.Integration.Tools;

namespace Unik.Marketing.Integration.Service.Model
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