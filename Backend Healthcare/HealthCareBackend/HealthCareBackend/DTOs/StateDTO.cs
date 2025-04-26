using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class StateDTO
    {
        [Key]
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
    }
}
