using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController:ControllerBase
    {
        private readonly PatientDetailService _patientDetailService;
        public PatientDetailsController(PatientDetailService patientDetailService)
        {
            _patientDetailService = patientDetailService;

        }
        [HttpGet("Get-PatientDetails/{userId}")]
        public ActionResult<List<PatientDetailsDTO>> GetPatientDetailsbyId(int userId)
        {
            var patient = _patientDetailService.GetPateientDetailsById(userId);
            return Ok(patient);
        }


    }

}
