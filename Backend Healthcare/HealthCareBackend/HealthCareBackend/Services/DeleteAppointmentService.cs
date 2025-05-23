using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class DeleteAppointmentService
    {
        private readonly DeleteAppointmentRepository _repository;

        public DeleteAppointmentService(DeleteAppointmentRepository repository)
        {
            _repository = repository;
        }

        public void UpdateAppointmentIsDeleted(int appointmentId)
        {
            _repository.UpdateAppointmentIsDeleted(appointmentId);
        }
    }
}
