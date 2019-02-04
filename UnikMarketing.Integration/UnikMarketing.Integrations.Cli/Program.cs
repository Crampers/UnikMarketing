using System;
using System.Data.SqlClient;
using System.IO;
using UnikMarketing.Integration.Tools;

namespace UnikMarketing.Integrations.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                PrintHelpAndExit(args);
            }
            else
            {
                string connectionString = args[0];
                string fileName = args[1];
                SequelToJson sqJson = new SequelToJson(new SqlConnection(connectionString));

                var jsonResult = sqJson.GetJson();
                File.WriteAllText(fileName, jsonResult);
            }
        }

        private static void PrintHelpAndExit(string[] args)
        {
            Console.WriteLine(@"Usage: dotnet UnikMarketing.Integration.Tool.dll <ConnectionString> <FilePath>");
            Environment.Exit(1);
        }
    }
}
