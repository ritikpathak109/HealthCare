using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class MasterTableService
    {
        private readonly MasterTableRepository _masterTableRepository;
        public MasterTableService(MasterTableRepository masterTableRepository)
        {
            _masterTableRepository = masterTableRepository;
        }

        public List<CountryDTO> GetCountry()
        {
            return _masterTableRepository.GetCountries();
        }
        public List<StateDTO> GetStateByCountryId(int countryId)
        {
            return _masterTableRepository.GetStatesByCountryId(countryId);
        }
        public List<RoleDTO> GetRole()
        {
            return _masterTableRepository.GetRoles();
        }
        public List<GenderDTO> GetGender()
        {
            return _masterTableRepository.GetGenders();
        }
        public List<DoctorSpecializationDTO> GetSpecializations()
        {
            return _masterTableRepository.GetSpecialization();
        }

    }
}
