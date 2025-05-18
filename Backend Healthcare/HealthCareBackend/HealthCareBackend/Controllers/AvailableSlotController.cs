using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableSlotController:ControllerBase
    {
        private readonly AvailableSlotService _service;

        public AvailableSlotController(AvailableSlotService service)
        {
            _service = service;
        }

        [HttpGet("GetAvailable-Slots")]
        public ActionResult<List<SlotDTO>> GetAvailableSlots(int doctorId, DateTime appointmentDate)
        {
            var slots = _service.GetAvailableSlots(doctorId, appointmentDate);
            return Ok(slots);
        }
    }
}
