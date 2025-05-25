using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace HealthCareBackend.Repositories
{
    public class DeletedAppointmentDetailsRepository
    {
        private readonly MyDbContext _context;

        public DeletedAppointmentDetailsRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<AppointmentResponseDTO> getDeletedAppointments(int patientId)
        {
            var param = new SqlParameter("@PatientId", patientId);
            return _context.USP_GetAppointmentsByPatientId.FromSqlRaw("EXEC GetDeletedAppointmentsByPatientId @PatientId", param).ToList();
        }
    }
}
