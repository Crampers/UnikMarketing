namespace Unik.Marketing.Integration.Service.Model
{
    public class SetupConfiguration
    {
        public readonly string ConnectionString;
        public readonly string CronScheduleExpression;
        public readonly string Destination;

        public SetupConfiguration(string connectionString, string cronScheduleExpression, string destination)
        {
            ConnectionString = connectionString;
            CronScheduleExpression = cronScheduleExpression;
            Destination = destination;
        }
    }
}
