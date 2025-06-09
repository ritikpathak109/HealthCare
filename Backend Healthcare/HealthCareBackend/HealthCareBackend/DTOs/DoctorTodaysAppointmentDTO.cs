using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class DoctorTodaysAppointmentDTO
    {
        [Key]

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? ReasonForVisit { get; set; }
        public DateOnly? AppointmentDate { get; set; } 
        public TimeSpan? AppointmentTime { get; set; }
    }
}
