using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorbySpecializationController:ControllerBase
    {
        private readonly DoctorbySpecializationService _service;

        public DoctorbySpecializationController(DoctorbySpecializationService service)
        {
            _service = service;
        }

        [HttpGet("GetDoctorsBySpecilization/{specializationId}")]
        public ActionResult<List<DoctorBySpecializationDTO>> GetDoctorsBySpecializationId(int specializationId)
        {
            var doctors = _service.GetDoctorsBySpecializationId(specializationId);
            return Ok(doctors);
        }
    }
}
