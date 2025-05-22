using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class AppointmentDetailsbyPatietntIdRepository
    {
        private readonly MyDbContext _context;

        public AppointmentDetailsbyPatietntIdRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<AppointmentResponseDTO> GetAppointmentsByPatientId(int patientId)
        {
            var param = new SqlParameter("@PatientId", patientId);
            return _context.USP_GetAppointmentsByPatientId.FromSqlRaw("EXEC USP_GetAppointmentsByPatientId @PatientId", param).ToList();
        }
    }
}
