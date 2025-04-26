
using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
   
            private readonly LoginService _loginService;

            public LoginController(LoginService loginService)
            {
                _loginService = loginService;
            }

            [HttpPost("LoginUser")]
            public IActionResult Login([FromBody] UserLoginDTO loginDTO)
            {
                var result = _loginService.ValidateLogin(loginDTO);

                if (result != null)
                {
                    return Ok(result); 
                }
                else
                {
                    return Unauthorized("Invalid username or password");
                }
            }
        }
    }

