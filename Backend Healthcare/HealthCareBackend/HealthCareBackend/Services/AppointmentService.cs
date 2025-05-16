using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _repository;

        public AppointmentService(AppointmentRepository repository)
        {
            _repository = repository;
        }

        public void AddAppointment(AppointmentDTO dto)
        {
            _repository.AddAppointment(dto);
        }
    }
}
