using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class GenderDTO
    {
        [Key]
        public int GenderId { get; set; }
        public string? Gender { get; set; }

    }
}
