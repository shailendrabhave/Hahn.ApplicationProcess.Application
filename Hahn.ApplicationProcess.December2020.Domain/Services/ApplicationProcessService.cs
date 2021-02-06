using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Hahn.ApplicationProcess.December2020.Domain.DTO;
using DAO = Hahn.ApplicationProcess.December2020.Data.DAO;
using AutoMapper;

namespace Hahn.ApplicationProcess.December2020.Domain.Services
{
    public class ApplicationProcessService : IApplicationProcessService
    {
        private readonly IMapper _mapper;
        public ApplicationProcessService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public DTO.Applicant GetApplicant(int id)
        {
            var applicant = new DAO.Applicant() { Id = 1, Name = "Shailendra", FamilyName = "Bhave", Age = 34, CountryOfOrigin = "India", EmailAddress = "bhave.shail@gmail.com" };
            return _mapper.Map<DTO.Applicant>(applicant);
        }

        public void AddNewApplicant(DTO.Applicant applicant)
        {

        }

        public void UpdateApplicant(DTO.Applicant applicant)
        {

        }

        public void DeleteApplicant(int id)
        {

        }
    }
}
