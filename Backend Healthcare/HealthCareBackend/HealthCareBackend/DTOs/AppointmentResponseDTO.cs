namespace HealthCareBackend.DTOs
{
    public class AppointmentResponseDTO
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string ReasonForVisit { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
