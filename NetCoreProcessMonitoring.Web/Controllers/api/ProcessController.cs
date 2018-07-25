using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCoreProcessMonitoring.Model;
using NetCoreProcessMonitoring.Model.Repositories;

namespace NetCoreProcessMonitoring.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly ProcessRepository _processRepository;
        private readonly ModuleRepository _moduleRepository;

        public ProcessController()
        {
            _processRepository = new ProcessRepository();
            _moduleRepository = new ModuleRepository();
        }

        [HttpGet]
        public IEnumerable<Process> GetAll(){
            return _processRepository.GetAllProcesses();
        }

        [HttpGet("{id}")]
        public IEnumerable<Module> Get(int id){
            return _moduleRepository.GetAllModulesForProcess(id);
        }
    }
}