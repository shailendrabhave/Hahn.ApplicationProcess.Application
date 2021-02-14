using Hahn.ApplicationProcess.December2020.Domain.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Web.Examples
{
    class ApplicantExample : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            return new Applicant
            {
                ID = 1,
                Name = "John",
                FamilyName = "Doe",
                Age = 34,
                Address = "Mumbai",
                CountryOfOrigin = "India",
                EmailAddress = "john.doe@microsoft.com",
                Hired = true
            };
        }
    }
}
