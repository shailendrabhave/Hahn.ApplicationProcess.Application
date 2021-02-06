using FluentValidation;
using Hahn.ApplicationProcess.December2020.Domain.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.December2020.Domain.Validators
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApplicantValidator(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

            RuleFor(applicant => applicant.Name).MinimumLength(5).WithMessage("Name should contain at least 5 characters");
            RuleFor(applicant => applicant.FamilyName).MinimumLength(5).WithMessage("Family name should contain at least 5 characters");
            RuleFor(applicant => applicant.Address).MinimumLength(5).WithMessage("Address should contain at least 10 characters");
            RuleFor(applicant => applicant.EmailAddress).EmailAddress().WithMessage("Email address must be valid");
            RuleFor(applicant => applicant.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(50).WithMessage("Age must be between 20 and 60");
            RuleFor(applicant => applicant.Hired).NotNull().WithMessage("Hired cannot be null");

            RuleFor(applicant => applicant.CountryOfOrigin).MustAsync(async (countryOfOrigin, cancellation) => {
                bool coutryExists = await ValidateCountryOfOrigin(countryOfOrigin);
                return coutryExists;
            }).WithMessage("Country of origin must be valid");
        }

        private async Task<bool> ValidateCountryOfOrigin(string countryOrOrigin) 
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://restcountries.eu/rest/v2/name/"+ countryOrOrigin + "?fullText=true");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
