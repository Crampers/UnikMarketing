using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace UnikMarketing.Integration.Service
{
    internal class DynamicJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var action = context.MergedJobDataMap.Get("action") as Func<Task>;

            await action();
        }
    }
}
