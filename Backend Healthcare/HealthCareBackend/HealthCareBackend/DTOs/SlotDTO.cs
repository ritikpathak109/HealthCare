using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class SlotDTO
    {
        [Key]
        public int SlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int IsBooked { get; set; }
    }
}
