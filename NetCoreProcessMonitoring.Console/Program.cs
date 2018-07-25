using System;
using System.Linq;
using NetCoreProcessMonitoring.Model;
using NetCoreProcessMonitoring.Model.Repositories;

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
            var repo = new ProcessRepository();
            foreach (Process process in repo.GetAllProcesses())
            {

                System.Console.WriteLine($"{process.Id} - {process.Name}");

            }
        }

        static void ShowModulesFromProcess(int pid)
        {
            var modulesRepo = new ModuleRepository();

            foreach (Module module in modulesRepo.GetAllModulesForProcess(pid))
            {
                System.Console.WriteLine($"{module.Name} - {module.Version}");
            }
        }
    }
}
