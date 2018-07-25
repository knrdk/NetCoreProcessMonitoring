using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetCoreProcessMonitoring.Model;

namespace NetCoreProcessMonitoring.Model.Repositories {
    public class ModuleRepository{

        public IEnumerable<Module> GetAllModulesForProcess(int processId){
            var process = System.Diagnostics.Process.GetProcessById(processId);

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

                yield return new Module(asProcessModule.ModuleName, version);
            }
        }
    }
}