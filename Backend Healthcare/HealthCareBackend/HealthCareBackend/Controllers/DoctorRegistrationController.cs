using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DoctorRegistrationController: ControllerBase
    {
        private readonly DoctorRegistrationService _doctorRegistrtaionService;

        public DoctorRegistrationController(DoctorRegistrationService doctorRegistrtaionService)
        {
            _doctorRegistrtaionService = doctorRegistrtaionService;
        }

        [HttpPost("Register-Doctor")]
        public IActionResult RegisterDoctor([FromBody] DoctorRegistrationDTO doctorDto)
        {
            if (doctorDto == null)
            {
                return BadRequest("Doctor registration data is required.");
            }

            _doctorRegistrtaionService.RegisterDoctor(doctorDto);

            return Ok(new { Message = "Doctor registered successfully." });
        }
    }
}
