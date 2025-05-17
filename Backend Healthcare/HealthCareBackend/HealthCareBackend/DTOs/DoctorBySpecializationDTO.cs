using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class DoctorBySpecializationDTO
    {
   
            [Key]
            public int DoctorId { get; set; }
            public string DoctorFullName { get; set; }
            public int SpecializationId { get; set; }
        
    }
}
