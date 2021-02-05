using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.DTO;

namespace Hahn.ApplicationProcess.December2020.Domain.Services
{
    public class ApplicationProcessService : IApplicationProcessService
    {
        public Applicant GetApplicant(int id)
        {
            return new Applicant();
        }

        public void AddNewApplicant(Applicant applicant)
        {

        }

        public void UpdateApplicant(Applicant applicant)
        {

        }

        public void DeleteApplicant(int id)
        {

        }
    }
}
