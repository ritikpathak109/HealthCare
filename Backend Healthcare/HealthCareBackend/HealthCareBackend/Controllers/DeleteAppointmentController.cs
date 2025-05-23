using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DeleteAppointmentController: ControllerBase
    {
        private readonly DeleteAppointmentService _service;

        public DeleteAppointmentController(DeleteAppointmentService service)
        {
            _service = service;
        }

        [HttpPut("Delete-Appointment")]
        public IActionResult SoftDeleteAppointment(int appointmentId)
        {
            _service.UpdateAppointmentIsDeleted(appointmentId);
            return Ok("Appointment Deleted Successfully");
        }

    }
}
