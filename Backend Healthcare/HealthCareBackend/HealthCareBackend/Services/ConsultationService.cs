using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class ConsultationService
    {
        private readonly ConsultationRepository _consultationRepository;

        public ConsultationService(ConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public void AddConsultation(ConsultationDTO consultationDTO)
        {
            _consultationRepository.AddConsultation(consultationDTO);
        }
    }
}
