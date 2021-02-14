using Hahn.ApplicationProcess.December2020.Domain.DTO;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Hahn.ApplicationProcess.December2020.Web.Examples
{
    class ListApplicantExample : IExamplesProvider<IEnumerable<Applicant>>
    {
        public IEnumerable<Applicant> GetExamples()
        {
            // An example without a summary.
            yield return new Applicant {
                    ID = 1,
                    Name = "John",
                    FamilyName = "Doe",
                    Age = 34,
                    Address = "Mumbai",
                    CountryOfOrigin = "India",
                    EmailAddress = "john.doe@microsoft.com",
                    Hired = true
                };

            yield return new Applicant
            {
                ID = 1,
                Name = "Bob",
                FamilyName = "Smith",
                Age = 28,
                Address = "Pune",
                CountryOfOrigin = "India",
                EmailAddress = "bob.smith@microsoft.com",
                Hired = true
            };
        }
    }
}
