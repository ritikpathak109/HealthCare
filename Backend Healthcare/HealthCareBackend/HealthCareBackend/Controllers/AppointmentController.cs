using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class AppointmentController : ControllerBase
        {
            private readonly AppointmentService _service;

            public AppointmentController(AppointmentService service)
            {
                _service = service;
            }

            [HttpPost("add-appointment")]
            public IActionResult AddAppointment([FromBody] AppointmentDTO dto)
            {
                _service.AddAppointment(dto);
                return Ok("Appointment registered successfully");
            }
        }
    
}
