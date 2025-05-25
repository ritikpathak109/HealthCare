using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{ 
        public class DeletedAppointmentDetailsService
    {
            private readonly DeletedAppointmentDetailsRepository _repository;

            public DeletedAppointmentDetailsService(DeletedAppointmentDetailsRepository repository)
            {
                _repository = repository;
            }

            public List<AppointmentResponseDTO> getDeletedAppointmentDetails(int patientId)
            {
                return _repository.getDeletedAppointments(patientId);
            }
        }
    
}
