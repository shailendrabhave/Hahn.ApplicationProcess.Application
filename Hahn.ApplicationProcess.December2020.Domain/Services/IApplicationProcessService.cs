using Hahn.ApplicationProcess.December2020.Domain.DTO;

namespace Hahn.ApplicationProcess.December2020.Domain.Services
{
    public interface IApplicationProcessService
    {
        void AddNewApplicant(Applicant applicant);
        void DeleteApplicant(int id);
        Applicant GetApplicant(int id);
        void UpdateApplicant(Applicant applicant);
    }
}