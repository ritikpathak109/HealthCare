using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class DoctorRegistrationDTO
    {
        [Key]

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public DateTime DoctorDateOfBirth { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorAddress { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int SpecializationId { get; set; }
        public int ExperienceYears { get; set; }

    }
}
