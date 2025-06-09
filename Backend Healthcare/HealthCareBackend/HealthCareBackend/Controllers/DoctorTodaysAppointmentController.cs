using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorTodaysAppointmentController:ControllerBase
    {

        private readonly DoctorTodaysAppointmentService _doctorTodaysAppointmentService;
        public DoctorTodaysAppointmentController(DoctorTodaysAppointmentService doctorTodaysAppointmentService)
        {
            _doctorTodaysAppointmentService = doctorTodaysAppointmentService;

        }
        [HttpGet("Get-TodaysDoctorAppointments")]
        public ActionResult<List<DoctorDetailsDTO>> GetFDoctorDetailsbyId(int doctorId)
        {
            var appointment = _doctorTodaysAppointmentService.GetTodaysDoctorAppointments(doctorId);
            return Ok(appointment);
        }


    }
}
