using Hahn.ApplicationProcess.December2020.Domain.DTO;
using Hahn.ApplicationProcess.December2020.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Hahn.ApplicationProcess.December2020.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationProcessController : ControllerBase
    {
        private readonly IApplicationProcessService _applicationProcessService;
        private readonly ILogger<ApplicationProcessController> _logger;

        public ApplicationProcessController(IApplicationProcessService applicationProcessService, 
            ILogger<ApplicationProcessController> logger)
        {
            _logger = logger;
            _applicationProcessService = applicationProcessService;
        }
        [HttpGet]
        public IEnumerable<Applicant> Get()
        {
            return _applicationProcessService.GetAllApplicants();
        }

        [HttpGet("{id:int}")]
        public Applicant Get(int id)
        {
            var applicant = _applicationProcessService.GetApplicant(id);
            return applicant;
        }

        [HttpPost]
        public void ActionResult(Applicant applicant)
        {
            _applicationProcessService.AddNewApplicant(applicant);
        }

        [HttpPut]
        public void Put(Applicant applicant)
        {
            _applicationProcessService.UpdateApplicant(applicant);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _applicationProcessService.DeleteApplicant(id);
        }
    }
}
