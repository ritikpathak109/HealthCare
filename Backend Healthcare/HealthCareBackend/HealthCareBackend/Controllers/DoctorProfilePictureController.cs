using HealthCareBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorProfilePictureController : ControllerBase
    {
        private readonly DoctorProfilePictureService _service;
        private readonly IWebHostEnvironment _environment;

        public DoctorProfilePictureController(DoctorProfilePictureService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpPost("Upload/{userId}")]
        public IActionResult UploadProfilePicture(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var uploadPath = Path.Combine(_environment.WebRootPath, "ProfilePicture");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var result = _service.SaveProfilePicture(userId, fileName);

            if (result)
                return Ok(new { Message = "Profile picture uploaded successfully", FileName = fileName });
            else
                return StatusCode(500, "Something went wrong.");
        }

        [HttpGet("Get/{userId}")]
        public IActionResult GetProfilePicture(int userId)
        {
            var fileName = _service.GetProfilePictureFileName(userId);

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "default.jpg";
            }

            var filePath = Path.Combine(_environment.WebRootPath, "ProfilePicture", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Profile picture file not found on server.");
            }

            var contentType = "image/" + Path.GetExtension(filePath).TrimStart('.');
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, contentType);
        }
    }
}
