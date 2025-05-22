using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class AppointmentResponseDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string SpecializationName { get; set; }
        public string DoctorName { get; set; }
        public TimeSpan SlotStartTime { get; set; }
        public TimeSpan SlotEndTime { get; set; }
        public string ReasonForVisit { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
