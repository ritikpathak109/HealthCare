using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class PatientDetailsDTO
    {
        [Key]
            public int PatientId { get; set; }
            public int UserId { get; set; }
            public string? UserEmail { get; set; }
            public string? PatientFirstName { get; set; }
            public string? PatientLastName { get; set; }
            public string? PatientPhoneNumber { get; set; }
            public string? PatientAddress { get; set; }
            public string? Gender { get; set; }
            public string? CountryName { get; set; }
            public string?  StateName { get; set; }
            public int Age { get; set; }
            public string? ProfilePicture { get; set; }


    }
}

