using HealthCareBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class PatientProfilePictureRepository
    {
        private readonly MyDbContext _context;

        public PatientProfilePictureRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveProfilePictureAsync(int userId, string fileName)
        {
            var patient = await _context.PatientsDetails.SingleOrDefaultAsync(p => p.UserId == userId);

            if (patient == null)
            {
                throw new Exception("Patient not found.");
            }

            // Optional: Delete old picture if exists
            if (!string.IsNullOrEmpty(patient.ProfilePicture))
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProfilePicture", patient.ProfilePicture);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }

            // Save new profile picture name
            patient.ProfilePicture = fileName;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
