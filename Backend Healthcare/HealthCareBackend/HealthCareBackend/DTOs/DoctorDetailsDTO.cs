using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class DoctorDetailsDTO
    {
        [Key]
        public int DoctorId { get; set; }
        public string? DoctorFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public string? DoctorEmail { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public string? Gender { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public string? DoctorProfilePicture { get; set; }
        public string? DoctorAddress { get; set; }
        public string? DoctorPhoneNumber { get; set; }
        public string? SpecializationName { get; set; }
        public int ExperienceYears { get; set; }
    
    }
}
