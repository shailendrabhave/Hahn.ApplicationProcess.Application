using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data;
using System;
using System.Collections.Generic;
using DAO = Hahn.ApplicationProcess.December2020.Data.DAO;

namespace Hahn.ApplicationProcess.December2020.Domain.Services
{
    public class ApplicationProcessService : IApplicationProcessService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DAO.Applicant> _repository;
        public ApplicationProcessService(IMapper mapper, IRepository<DAO.Applicant> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public IEnumerable<DTO.Applicant> GetAllApplicants()
        {
            var applicants = _repository.GetAll();
            return _mapper.Map<IEnumerable<DTO.Applicant>>(applicants);
        }
        public DTO.Applicant GetApplicant(int id)
        {
            var applicant = _repository.Get(id);
            return _mapper.Map<DTO.Applicant>(applicant);
        }

        public void AddNewApplicant(DTO.Applicant applicant)
        {
            var applicationDAO = _mapper.Map<DAO.Applicant>(applicant);
            _repository.Insert(applicationDAO);
        }

        public void UpdateApplicant(DTO.Applicant applicant)
        {
            var applicationDAO = _mapper.Map<DAO.Applicant>(applicant);
            applicationDAO.ModifiedDate = DateTime.Now;
            _repository.Update(applicationDAO);
        }

        public void DeleteApplicant(int id)
        {
            var applicant = _repository.Get(id);
            _repository.Delete(applicant);
        }
    }
}
