using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class PatientDetailsRepository
    {
        private readonly MyDbContext _context;

        public PatientDetailsRepository(MyDbContext context)
        {
            _context = context;

        }

        public List<PatientDetailsDTO> GetPateintbyId(int userId)
        {
            var param = new SqlParameter("@UserId", userId);

            return _context.USP_GetPatientProfile.FromSqlRaw("EXEC USP_GetPatientProfile @UserId", param).ToList();
        }


    }

}
