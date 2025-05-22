using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class AppointmentDetailsbyPatientIdService
    {
        private readonly AppointmentDetailsbyPatietntIdRepository _repository;

        public AppointmentDetailsbyPatientIdService(AppointmentDetailsbyPatietntIdRepository repository)
        {
            _repository = repository;
        }

        public List<AppointmentResponseDTO> GetAppointmentsByPatientId(int patientId)
        {
            return _repository.GetAppointmentsByPatientId(patientId);
        }
    }
}
