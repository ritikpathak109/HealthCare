using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class DeleteAppointmentDTO
    {
        [Key]
            public int AppointmentId { get; set; }
            public bool IsDeleted { get; set; }
        
    }
}
