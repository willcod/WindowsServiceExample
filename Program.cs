using System;
using System.ServiceProcess;

namespace WindowsServiceExample
{
    internal class Program
    {
        private static void Main(string[] args) {
            if ((!Environment.UserInteractive)) {
                Program.RunAsAService();
            }
            else {
                if (args != null && args.Length > 0) {
                    if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase)) {
                        SelfInstaller.InstallMe();
                    }
                    else {
                        if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase)) {
                            SelfInstaller.UninstallMe();
                        }
                        else {
                            Console.WriteLine("Invalid argument!");
                        }
                    }
                }
                else {
                    Program.RunAsAConsole();
                }
            }
        }

        private static void RunAsAConsole() {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.Execute();
        }

        private static void RunAsAService() {
            ServiceBase[] servicesToRun = new ServiceBase[]
            {
                new ExampleService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}