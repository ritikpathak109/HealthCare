using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController:ControllerBase
    {
        private readonly ConsultationService _consultationService;

        public ConsultationController(ConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpPost("Add-Consultaion")]
        public IActionResult AddConsultation([FromBody] ConsultationDTO consultationDTO)
        {

            _consultationService.AddConsultation(consultationDTO);

            return Ok(new { Message = "Consultation Done Successfully." });
        }
    }
}
