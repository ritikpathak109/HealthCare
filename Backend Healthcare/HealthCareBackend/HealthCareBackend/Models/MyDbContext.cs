using HealthCareBackend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) {}

        public DbSet<LoginResultDTO> LoginResult { get; set; }


    }
}
