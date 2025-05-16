using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class GetAppointmentDetailsService
    {
        private readonly GetAppointmentDetailsRepository _getAppointmentDetailsrepository;

        public GetAppointmentDetailsService(GetAppointmentDetailsRepository getAppointmentDetailsrepository)
        {
            _getAppointmentDetailsrepository = getAppointmentDetailsrepository;
        }

        public List<AppointmentResponseDTO> GetAllAppointments()
        {
            return _getAppointmentDetailsrepository.GetAllAppointments();
        }
    }
}
