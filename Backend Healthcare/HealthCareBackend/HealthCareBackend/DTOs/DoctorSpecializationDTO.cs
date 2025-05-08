using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class DoctorSpecializationDTO
    {
        [Key]
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
    }
}
