using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class DoctorRegistrationService
    {
        private readonly DoctorRegistrationRepository _doctorRegisterRepository;

        public DoctorRegistrationService(DoctorRegistrationRepository doctorRegisterRepository)
        {
            _doctorRegisterRepository = doctorRegisterRepository;
        }

        public void RegisterDoctor(DoctorRegistrationDTO doctorDto)
        {
            _doctorRegisterRepository.InsertDoctor(doctorDto);
        }
        
    }
}
