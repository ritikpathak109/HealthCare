using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAppointmentDetailsController:ControllerBase
    {
        private readonly GetAppointmentDetailsService _getAppointmentDetailsservice;

        public GetAppointmentDetailsController(GetAppointmentDetailsService getAppointmentDetailsservice)
        {
            _getAppointmentDetailsservice = getAppointmentDetailsservice;
        }

        [HttpGet("GetAllAppointments")]
        public IActionResult GetAllAppointments()
        {
            var appointments = _getAppointmentDetailsservice.GetAllAppointments();
            return Ok(appointments);
        }
    }
}
