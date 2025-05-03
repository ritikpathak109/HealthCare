using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class PatientDetailService
    {
        private readonly PatientDetailsRepository _patientDetailsRepository;
        public PatientDetailService(PatientDetailsRepository masterTableRepository)
        {
            _patientDetailsRepository = masterTableRepository;
        }
        public List<PatientDetailsDTO> GetPateientDetailsById(int countryId)
        {
            return _patientDetailsRepository.GetPateintbyId(countryId);
        }

    }
}
