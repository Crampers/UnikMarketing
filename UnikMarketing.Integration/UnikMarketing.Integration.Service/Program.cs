using System.ServiceProcess;

namespace UnikMarketing.Integration.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new UmIntegrationService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
