using System.ComponentModel.DataAnnotations;

namespace HealthCareBackend.DTOs
{
    public class UserLoginDTO
    {
        [Key]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        
    }
}
