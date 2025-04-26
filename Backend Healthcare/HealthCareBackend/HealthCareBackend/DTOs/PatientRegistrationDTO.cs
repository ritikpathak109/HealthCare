

using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class PatientRegistrationDTO
    {
        [Key]
            public string PatientFirstName { get; set; }
            public string PatientLastName { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
            public string UserPassword { get; set; }
            public int RoleId { get; set; }
            public DateTime DateofBirth { get; set; }
            public int GenderId { get; set; }
            public int CountryId { get; set; }
            public int StateId { get; set; }
            public string PatientAddress { get; set; }
            public string PatientPhoneNumber { get; set; }
    }

}
