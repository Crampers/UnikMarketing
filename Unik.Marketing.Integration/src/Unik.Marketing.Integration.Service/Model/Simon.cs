using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Unik.Marketing.Integration.Service.Model
{
    public class Simon
    {
        public readonly string ConnectionString;
        public readonly string CronScheduleExpression;
        public readonly string Destination;

        public Simon(string connectionString, string cronScheduleExpression, string destination)
        {
            ConnectionString = connectionString;
            CronScheduleExpression = cronScheduleExpression;
            Destination = destination;
        }
    }
}
