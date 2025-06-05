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

        public bool SaveProfilePicture(int userId, string fileName)
        {
        
            var patient = _context.PatientsDetails.SingleOrDefault(p => p.UserId == userId);

            if (patient == null)
            {
                throw new Exception("Patient not found.");
            }

            if (!string.IsNullOrEmpty(patient.ProfilePicture))
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProfilePicture", patient.ProfilePicture);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }

            patient.ProfilePicture = fileName;
            _context.SaveChanges();

            return true;
        }

        public string? GetProfilePictureFileName(int userId)
        {
            var patient = _context.PatientsDetails
                .AsNoTracking()
                .SingleOrDefault(p => p.UserId == userId);

            return patient?.ProfilePicture;
        }
    }
}
