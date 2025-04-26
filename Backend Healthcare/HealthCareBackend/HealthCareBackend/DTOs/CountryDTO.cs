using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class CountryDTO
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
