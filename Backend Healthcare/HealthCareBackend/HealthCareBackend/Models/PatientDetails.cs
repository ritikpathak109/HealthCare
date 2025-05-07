using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareBackend.Models
{
   
    public class PatientDetails
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public int UserId { get; set; }
        public string PatientLastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string PatientAddress { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
