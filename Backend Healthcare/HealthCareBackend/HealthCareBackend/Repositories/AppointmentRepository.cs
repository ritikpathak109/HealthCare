using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class AppointmentRepository
    {

        private readonly MyDbContext _context;

        public AppointmentRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AddAppointment(AppointmentDTO dto)
        {
            var parameters = new[]
            {
                new SqlParameter("@PatientId", dto.PatientId),
                new SqlParameter("@DoctorId", dto.DoctorId),
                new SqlParameter("@AppointmentDate", dto.AppointmentDate),
                new SqlParameter("@AppointmentTime", dto.AppointmentTime),
                new SqlParameter("@ReasonForVisit", dto.ReasonForVisit),
                new SqlParameter("@StatusId", dto.StatusId)
            };

            _context.Database.ExecuteSqlRaw( "EXEC USP_AddAppointment @PatientId, @DoctorId, @AppointmentDate, @AppointmentTime, @ReasonForVisit, @StatusId",
                parameters
            );
        }
    }
}
