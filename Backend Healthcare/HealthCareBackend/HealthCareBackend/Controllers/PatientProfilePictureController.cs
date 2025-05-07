using HealthCareBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProfilePictureController : ControllerBase
    {
        private readonly PatientProfilePictureService _service;
        private readonly IWebHostEnvironment _environment;

        public PatientProfilePictureController(PatientProfilePictureService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpPost("Upload/{userId}")]
        public async Task<IActionResult> UploadProfilePicture(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Generate unique file name
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var uploadPath = Path.Combine(_environment.WebRootPath, "ProfilePicture");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, fileName);

            // Save file to server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Save file name to DB
            var result = await _service.SaveProfilePictureAsync(userId, fileName);

            if (result)
                return Ok(new { Message = "Profile picture uploaded successfully", FileName = fileName });
            else
                return StatusCode(500, "Something went wrong.");
        }
    }
}
