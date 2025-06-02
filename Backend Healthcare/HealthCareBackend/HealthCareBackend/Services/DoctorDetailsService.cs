using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class DoctorDetailsService
    {
        private readonly DoctorDetailsRepository _doctorDetailsRepository;
        public DoctorDetailsService(DoctorDetailsRepository doctorDetailsRepository)
        {
            _doctorDetailsRepository = doctorDetailsRepository;
        }
        public List<DoctorDetailsDTO> GetDoctorDetailsById(int userId)
        {
            return _doctorDetailsRepository.GetDoctorId(userId);
        }
    }
}
