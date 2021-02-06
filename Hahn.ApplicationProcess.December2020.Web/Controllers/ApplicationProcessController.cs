using Hahn.ApplicationProcess.December2020.Domain.DTO;
using Hahn.ApplicationProcess.December2020.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            _logger.LogInformation(String.Format("Get method called for all applicants"));
            return _applicationProcessService.GetAllApplicants();
        }

        [HttpGet("{id:int}")]
        public Applicant Get(int id)
        {
            _logger.LogInformation(String.Format("Get method called for the applicant id {0}",id));
            var applicant = _applicationProcessService.GetApplicant(id);
            return applicant;
        }

        [HttpPost]
        public void Post(Applicant applicant)
        {
            _logger.LogInformation(String.Format("Adding new applicant with the name {0}", applicant.Name));
            _applicationProcessService.AddNewApplicant(applicant);
        }

        [HttpPut]
        public void Put(Applicant applicant)
        {
            _logger.LogInformation(String.Format("Updating applicant with the id {0}", applicant.ID));
            _applicationProcessService.UpdateApplicant(applicant);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _logger.LogInformation(String.Format("Deleting applicant with the id {0}", id));
            _applicationProcessService.DeleteApplicant(id);
        }
    }
}
