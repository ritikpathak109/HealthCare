using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class AppointmentStatusDTO
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
