using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class AvailableSlotRepository
    {
        private readonly MyDbContext _context;

        public AvailableSlotRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<SlotDTO> GetAvailableSlots(int doctorId, DateTime appointmentDate)
        {
            var doctorParam = new SqlParameter("@DoctorId", doctorId);
            var dateParam = new SqlParameter("@AppointmentDate", appointmentDate);

            return _context.USP_GetAvailableSlots.FromSqlRaw("EXEC USP_GetAvailableSlots @DoctorId, @AppointmentDate", doctorParam, dateParam).ToList();
        }
    }
}
