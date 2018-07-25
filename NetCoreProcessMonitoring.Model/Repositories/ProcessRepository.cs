using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetCoreProcessMonitoring.Model;

namespace NetCoreProcessMonitoring.Model.Repositories {
    public class ProcessRepository{

        public IEnumerable<Process> GetAllProcesses(){
            return System.Diagnostics.Process.GetProcesses().Select(Map);
        }

        private Process Map(System.Diagnostics.Process process){
            return new Process(process.Id, process.ProcessName);
        } 
    }
}