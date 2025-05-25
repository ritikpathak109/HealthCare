using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeletedAppointmentDetailsController:ControllerBase
    {
            private readonly DeletedAppointmentDetailsService _service;

            public DeletedAppointmentDetailsController(DeletedAppointmentDetailsService service)
            {
                _service = service;
            }

            [HttpGet("GetDeletedAppointmentDetailsbyPatientId")]
            public IActionResult GetAppointmentsByPatientId(int patientId)
            {
                var result = _service.getDeletedAppointmentDetails(patientId);
                return Ok(result);
            }
        }
    
}
