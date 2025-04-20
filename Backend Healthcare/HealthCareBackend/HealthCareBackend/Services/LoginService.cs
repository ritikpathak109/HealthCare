using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class LoginService
    {

        private readonly LoginRepository _loginRepository;
        public LoginService(LoginRepository loginRepository)
        {

            _loginRepository = loginRepository;
        }

        public LoginResultDTO ValidateLogin(UserLoginDTO loginDTO)
        {
            return _loginRepository.ValidateLogin(loginDTO);
        }

    }
}
