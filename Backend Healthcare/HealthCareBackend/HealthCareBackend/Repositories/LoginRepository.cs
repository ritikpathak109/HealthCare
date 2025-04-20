using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class LoginRepository
    {
        private readonly MyDbContext _context;

        public LoginRepository(MyDbContext context)
        {
            _context = context;

        }

        public LoginResultDTO ValidateLogin(UserLoginDTO loginDTO)
        {
            var parameter = new[]{
                new SqlParameter("@UserName", loginDTO.UserName),
                new SqlParameter("@UserPassword", loginDTO.UserPassword)
            };
            var user = _context.LoginResult.FromSqlRaw("EXEC dbo.USP_UserLogin @UserName, @UserPassword", parameter).AsEnumerable().FirstOrDefault();

            return user;
        }

    }
}
