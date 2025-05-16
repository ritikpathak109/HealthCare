using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string ReasonForVisit { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
