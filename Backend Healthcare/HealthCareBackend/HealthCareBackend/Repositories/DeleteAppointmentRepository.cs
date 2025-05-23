using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class DeleteAppointmentRepository
    {

        private readonly MyDbContext _context;

        public DeleteAppointmentRepository(MyDbContext context)
        {
            _context = context;
        }
        public void UpdateAppointmentIsDeleted(int appointmentId)
        {
            var parameters = new[]
            {
                new SqlParameter("@AppointmentId", appointmentId),
            };

            _context.Database.ExecuteSqlRaw("EXEC usp_UpdateAppointmentIsDeleted @AppointmentId", parameters);
        }
    }
}
