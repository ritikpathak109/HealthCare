using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class PatientRegistrationService
    {
        private readonly PatientRegistrationRepository _patientRegisterRepository;

        public PatientRegistrationService(PatientRegistrationRepository patientRegisterRepository)
        {
            _patientRegisterRepository = patientRegisterRepository;
        }

        public void RegisterPatient(PatientRegistrationDTO patientDto)
        {
            _patientRegisterRepository.InsertPatient(patientDto);
        }
    }
}

