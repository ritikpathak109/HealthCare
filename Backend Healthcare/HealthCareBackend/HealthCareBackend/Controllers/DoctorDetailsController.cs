using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorDetailsController:ControllerBase
    {
        private readonly DoctorDetailsService _doctorDetailService;
        public DoctorDetailsController(DoctorDetailsService doctorDetailService)
        {
            _doctorDetailService = doctorDetailService;

        }
        [HttpGet("Get-DoctorDetails/{userId}")]
        public ActionResult<List<DoctorDetailsDTO>> GetFDoctorDetailsbyId(int userId)
        {
            var doctor = _doctorDetailService.GetDoctorDetailsById(userId);
            return Ok(doctor);
        }
    }
}
