using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;
using static HealthCareBackend.DTOs.DoctorBySpecializationDTO;

namespace HealthCareBackend.Services
{
    public class DoctorbySpecializationService

    {

        private readonly DoctorbySpecializationRepository _repository;

        public DoctorbySpecializationService(DoctorbySpecializationRepository repository)
        {
            _repository = repository;
        }

        public List<DoctorBySpecializationDTO> GetDoctorsBySpecializationId(int specializationId)
        {
            return _repository.GetDoctorsBySpecializationId(specializationId);
        }
    }
}
