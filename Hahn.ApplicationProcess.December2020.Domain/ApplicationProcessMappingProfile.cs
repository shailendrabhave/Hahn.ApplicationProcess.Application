using AutoMapper;
using DAO = Hahn.ApplicationProcess.December2020.Data.DAO;

namespace Hahn.ApplicationProcess.December2020.Domain
{
    public class ApplicationProcessMappingProfile : Profile
    {
        public ApplicationProcessMappingProfile()
        {
            CreateMap<DTO.Applicant, DAO.Applicant>().ReverseMap();
        }
    }
}
