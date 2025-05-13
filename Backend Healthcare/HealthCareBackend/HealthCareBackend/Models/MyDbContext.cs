using HealthCareBackend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) {}

        public DbSet<LoginResultDTO> LoginResult { get; set; }
        //public DbSet<PatientRegistrationDTO> PatientsDetails { get; set; }
        public DbSet<CountryDTO> CountryMaster { get; set; }
        public DbSet<StateDTO> StateMaster { get; set; }
        public DbSet<RoleDTO> RoleMaster { get; set; }
        public DbSet<GenderDTO> GenderMaster { get; set; }
        public DbSet<PatientDetailsDTO> USP_GetPatientProfile { get; set; }
        public DbSet<PatientDetails> PatientsDetails { get; set; }
        public DbSet<DoctorSpecializationDTO> DoctorSpecializationMaster { get; set; }
        public DbSet<AppointmentStatusDTO> AppointmentStatusMaster { get; set; }

    }
}
