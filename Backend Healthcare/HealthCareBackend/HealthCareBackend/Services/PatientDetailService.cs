using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class PatientDetailService
    {
        private readonly PatientDetailsRepository _patientDetailsRepository;
        public PatientDetailService(PatientDetailsRepository patientDetailsRepository)
        {
            _patientDetailsRepository = patientDetailsRepository;
        }
        public List<PatientDetailsDTO> GetPateientDetailsById(int userId)
        {
            return _patientDetailsRepository.GetPateintbyId(userId);
        }

    }
}
