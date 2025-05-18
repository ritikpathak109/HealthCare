using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class AvailableSlotService
    {
        private readonly AvailableSlotRepository _repository;

        public AvailableSlotService(AvailableSlotRepository repository)
        {
            _repository = repository;
        }

        public List<SlotDTO> GetAvailableSlots(int doctorId, DateTime appointmentDate)
        {
            return _repository.GetAvailableSlots(doctorId, appointmentDate);
        }
    }
}
