using System;
using System.Diagnostics;
using System.Linq;

namespace NetCoreProcessMonitoring.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                string arg = args.First();
                int pid = int.Parse(arg);
                ShowModulesFromProcess(pid);
            }
            else
            {
                ShowProcessess();
            }
        }

        static void ShowProcessess()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {

                System.Console.WriteLine($"{process.Id} - {process.ProcessName}");

            }
        }

        static void ShowModulesFromProcess(int pid)
        {
            Process process = Process.GetProcessById(pid);
            foreach (var x in process.Modules)
            {
                ProcessModule asProcessModule = (ProcessModule)x;
                if (asProcessModule == null)
                {
                    continue;
                }
                string version = "";
                try
                {
                    FileVersionInfo fileVersion = asProcessModule.FileVersionInfo;
                    version = fileVersion?.FileVersion ?? string.Empty;
                }
                catch (Exception)
                {
                    // TODO log
                }
                System.Console.WriteLine($"{asProcessModule.ModuleName} - {version}");
            }
        }
    }
}
