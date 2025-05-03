using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;

namespace HealthCareBackend.Repositories
{
    public class PatientDetailsRepository
    {
        private readonly MyDbContext _context;

        public PatientDetailsRepository(MyDbContext context)
        {
            _context = context;

        }

 

        public List<PatientDetailsDTO> PatientDetails(int userId)
        {
            var parameter = new[]{
                new SqlParameter("@UserId ", userId ),
                
            };
           return _context.USP_GetPatientProfile("EXEC USP_GetPatientProfile @UserId", parameter).ToList();


        }

    }

}
