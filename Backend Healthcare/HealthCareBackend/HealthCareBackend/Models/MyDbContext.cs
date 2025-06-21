using HealthCareBackend.DTOs;
using Microsoft.EntityFrameworkCore;
using static HealthCareBackend.DTOs.AppointmentDTO;

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
        public DbSet<DoctorDetailsDTO> USP_GetDoctorProfile { get; set; }
        public DbSet<PatientDetails> PatientsDetails { get; set; }

        public DbSet<DoctorDetails> DoctorDetails { get; set; }
        public DbSet<DoctorSpecializationDTO> DoctorSpecializationMaster { get; set; }
        public DbSet<AppointmentStatusDTO> AppointmentStatusMaster { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<AppointmentResponseDTO> USP_GetAppointmentsByPatientId { get; set; }
        public DbSet<SlotDTO> USP_GetAvailableSlots { get; set; }
        public DbSet<DoctorTodaysAppointmentDTO> USP_GetTodayApprovedAppointmentsForDoctor { get; set; }
        public DbSet<ConsultationDTO> USP_AddConsultationDetails { get; set; }
        public DbSet<MedicinesDTO> USP_GetAvailableMedicinesForDoctor { get; set; }


    }
}
