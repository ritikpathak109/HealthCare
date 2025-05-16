using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class GetAppointmentDetailsRepository
    {
        private readonly MyDbContext _context;

        public GetAppointmentDetailsRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<AppointmentResponseDTO> GetAllAppointments()
        {
            return _context.USP_GetAllAppointmentsDetails.FromSqlRaw("EXEC USP_GetAllAppointmentsDetails").ToList();
        }
    }
}
