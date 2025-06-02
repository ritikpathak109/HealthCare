using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class DoctorDetailsRepository
    {
        private readonly MyDbContext _context;

        public DoctorDetailsRepository(MyDbContext context)
        {
            _context = context;

        }

        public List<DoctorDetailsDTO> GetDoctorId(int userId)
        {
            var param = new SqlParameter("@UserId", userId);

            return _context.USP_GetDoctorProfile.FromSqlRaw("EXEC USP_GetDoctorProfile @UserId", param).ToList();
        }
    }
}
