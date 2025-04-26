using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase

    {
        private readonly PatientRegistrationService _patientRegistrtaionService;

        public PatientController(PatientRegistrationService patientRegistrtaionService)
        {
            _patientRegistrtaionService = patientRegistrtaionService;
        }

        [HttpPost("Register-Patient")]
        public IActionResult RegisterPatient([FromForm] PatientRegistrationDTO patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Patient registration data is required.");
            }

            _patientRegistrtaionService.RegisterPatient(patientDto);

            return Ok(new { Message = "Patient registered successfully." });
        }


    }
}
