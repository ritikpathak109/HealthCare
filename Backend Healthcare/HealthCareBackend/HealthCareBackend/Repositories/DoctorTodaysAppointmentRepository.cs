using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class DoctorTodaysAppointmentRepository
    {
        private readonly MyDbContext _context;

        public DoctorTodaysAppointmentRepository(MyDbContext context)
        {
            _context = context;

        }
        public List<DoctorTodaysAppointmentDTO> GetTodaysDoctorAppointments(int doctorId)
        {
            var param = new SqlParameter("@DoctorId", doctorId);
            return _context.USP_GetTodayApprovedAppointmentsForDoctor.FromSqlRaw("EXEC USP_GetTodayApprovedAppointmentsForDoctor @DoctorId", param).ToList();

        }
    }
}
