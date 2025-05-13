using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MasterTableController: ControllerBase
    {
        private readonly MasterTableService _masterTableService;
        public MasterTableController(MasterTableService masterTableService)
        {
            _masterTableService = masterTableService;

        }

        [HttpGet("Get-Countries")]
        public ActionResult<List<CountryDTO>> GetCountries()
        {
            var countries = _masterTableService.GetCountry();
            return Ok(countries);
        }

        [HttpGet("Get-States/{countryId}")]
        public ActionResult<List<StateDTO>> GetStates(int countryId)
        {
            var states = _masterTableService.GetStateByCountryId(countryId);
            return Ok(states);
        }


        [HttpGet("Get-Role")]
        public ActionResult<List<RoleDTO>> getRoles()
        {
            var roles = _masterTableService.GetRole();
            return Ok(roles);
        }

        [HttpGet("Get-Gender")]
        public ActionResult<List<RoleDTO>> getgender()
        {
            var gender = _masterTableService.GetGender();
            return Ok(gender);
        }

        [HttpGet("Get-DoctorSpecialization")]
        public ActionResult<List<DoctorSpecializationDTO>> getDoctorSpecialization()
        {
            var specialization = _masterTableService.GetSpecializations();
            return Ok(specialization);
        }

        [HttpGet("Get-AppointmentStatus")]
        public ActionResult<List<AppointmentStatusDTO>> getAppointmentStatus()
        {
            var status = _masterTableService.GetAppointmentStatuses();
            return Ok(status);
        }
    }
}
