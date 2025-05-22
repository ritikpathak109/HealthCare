using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentDetailsbyPatientIdController:ControllerBase
    {
        private readonly AppointmentDetailsbyPatientIdService _service;

        public AppointmentDetailsbyPatientIdController(AppointmentDetailsbyPatientIdService service)
        {
            _service = service;
        }

        [HttpGet("AppointmentDetailsbyPatientId")]
        public IActionResult GetAppointmentsByPatientId(int patientId)
        {
            var result = _service.GetAppointmentsByPatientId(patientId);
            return Ok(result);
        }
    }
}
