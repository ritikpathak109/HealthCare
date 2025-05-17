using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.Models
{
    public class DoctorDetails
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }
        public DateTime? Age { get; set; }
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string DoctorAddress { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public int SpecializationId { get; set; }
        public int ExperienceYears { get; set; }
        public byte IsActive { get; set; }
        public byte IsDeleted { get; set; }
    }
}
