using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class DoctorRegistrationRepository
    {
        private readonly MyDbContext _context;

        public DoctorRegistrationRepository(MyDbContext context)
        {
            _context = context;

        }

        public void InsertDoctor(DoctorRegistrationDTO doctorDto)
        {

            var parameters = new[]
            {
            new SqlParameter("@UserName", doctorDto.UserName),
            new SqlParameter("@UserPassword", doctorDto.UserPassword),
            new SqlParameter("@RoleId", doctorDto.RoleId),
            new SqlParameter("@DoctorFirstName", doctorDto.DoctorFirstName),
            new SqlParameter("@DoctorLastName", doctorDto.DoctorLastName),
            new SqlParameter("@DoctorPhoneNumber", doctorDto.DoctorPhoneNumber),
            new SqlParameter("@DoctorDateOfBirth", doctorDto.DoctorDateOfBirth),
            new SqlParameter("@DoctorEmail", doctorDto.DoctorEmail),
            new SqlParameter("@DoctorAddress", doctorDto.DoctorAddress),
            new SqlParameter("@GenderId", doctorDto.GenderId),
            new SqlParameter("@CountryId", doctorDto.CountryId),
            new SqlParameter("@StateId", doctorDto.StateId),
            new SqlParameter("@SpecializationId", doctorDto.SpecializationId),
            new SqlParameter("@ExperienceYears", doctorDto.ExperienceYears)
            };

            _context.Database.ExecuteSqlRaw("EXEC USP_RegisterDoctor @UserName, @UserPassword, @RoleId, @DoctorFirstName, @DoctorLastName, @DoctorPhoneNumber, @DoctorDateOfBirth, @DoctorEmail, @DoctorAddress, @GenderId, @CountryId, @StateId, @SpecializationId, @ExperienceYears ", parameters);
        }

    }
}
