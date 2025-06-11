using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class ConsultationDTO
    {
        [Key]

        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
 

        public string? SubjectiveNotes { get; set; }

        public string? BloodPressure { get; set; }
        public string? Pulse { get; set; }
        public string? Temperature { get; set; }
        public string? ObjectiveNotes { get; set; }

        public string? Assessment { get; set; }
        public string? GeneralAdvice { get; set; }

    }
}
