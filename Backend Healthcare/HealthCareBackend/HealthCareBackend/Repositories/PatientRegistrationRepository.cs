using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class PatientRegistrationRepository
    {
        private readonly MyDbContext _context;

        public PatientRegistrationRepository(MyDbContext context)
        {
            _context = context;

        }
        public void InsertPatient(PatientRegistrationDTO patientDto)
        {
           
            var parameters = new[]
            {
            new SqlParameter("@PatientFirstName", patientDto.PatientFirstName),
            new SqlParameter("@PatientLastName", patientDto.PatientLastName),
            new SqlParameter("@UserName", patientDto.UserName),
            new SqlParameter("@UserEmail", patientDto.UserEmail),
            new SqlParameter("@UserPassword", patientDto.UserPassword),
            new SqlParameter("@RoleId", patientDto.RoleId),
            new SqlParameter("@DateofBirth", patientDto.DateofBirth),
            new SqlParameter("@GenderId", patientDto.GenderId),
            new SqlParameter("@CountryId", patientDto.CountryId),
            new SqlParameter("@StateId", patientDto.StateId),
            new SqlParameter("@PatientAddress", patientDto.PatientAddress),
            new SqlParameter("@PatientPhoneNumber", patientDto.PatientPhoneNumber)
        };

            _context.Database.ExecuteSqlRaw("EXEC USP_RegisterPatient @PatientFirstName, @PatientLastName, @UserName, @UserEmail, @UserPassword, @RoleId, @DateofBirth, @GenderId, @CountryId, @StateId, @PatientAddress, @PatientPhoneNumber", parameters);
        }

    }
}
