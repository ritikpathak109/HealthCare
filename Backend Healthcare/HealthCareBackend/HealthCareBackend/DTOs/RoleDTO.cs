using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class RoleDTO
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
