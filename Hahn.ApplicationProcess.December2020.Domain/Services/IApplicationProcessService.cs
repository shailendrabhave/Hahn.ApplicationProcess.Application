using Hahn.ApplicationProcess.December2020.Domain.DTO;
using System.Collections.Generic;

namespace Hahn.ApplicationProcess.December2020.Domain.Services
{
    public interface IApplicationProcessService
    {
        IEnumerable<Applicant> GetAllApplicants();
        void AddNewApplicant(Applicant applicant);
        void DeleteApplicant(int id);
        Applicant GetApplicant(int id);
        void UpdateApplicant(Applicant applicant);
    }
}