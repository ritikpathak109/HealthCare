using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class LoginResultDTO
    {
        [Key]
        public string UserName { get; set; }
        public string RoleName { get; set; }

        public int RoleId { get; set; }
        public int UserId { get; set; }



    }
}
