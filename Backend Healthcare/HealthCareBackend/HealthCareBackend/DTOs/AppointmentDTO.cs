namespace HealthCareBackend.DTOs
{
    public class AppointmentDTO
    {
        public class Appointment
        {
            public int PatientId { get; set; }
            public int DoctorId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public TimeSpan AppointmentTime { get; set; }
            public string ReasonForVisit { get; set; }
            public int StatusId { get; set; } 
          

        }

    }
}
