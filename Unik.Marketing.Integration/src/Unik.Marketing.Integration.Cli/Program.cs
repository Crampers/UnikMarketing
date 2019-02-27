using System;
using System.IO;
using Unik.Marketing.Integration.Tools;

namespace Unik.Marketing.Integration.Cli
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

                var jsonResult = SequelToJson.GetSerializedJson(connectionString);
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
