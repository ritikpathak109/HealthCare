using HealthCareBackend.DTOs;
using HealthCareBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GetMedicinesController : ControllerBase
    {
        private readonly GetMedicinesService _medicineService;
        public GetMedicinesController(GetMedicinesService medicineService)
        {
            _medicineService = medicineService;

        }

        [HttpGet("Get-Medicine")]
        public ActionResult<List<CountryDTO>> GetCountries()
        {
            var medicine = _medicineService.GetMedicine();
            return Ok(medicine);
        }

    }
}
