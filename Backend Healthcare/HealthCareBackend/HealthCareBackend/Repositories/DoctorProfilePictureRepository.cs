using HealthCareBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{


        public class DoctorProfilePictureRepository
        {
            private readonly MyDbContext _context;

            public DoctorProfilePictureRepository(MyDbContext context)
            {
                _context = context;
            }

            public bool SaveProfilePicture(int userId, string fileName)
            {
                var doctor = _context.DoctorDetails.SingleOrDefault(d => d.UserId == userId);

                if (doctor == null)
                {
                    throw new Exception("Doctor not found.");
                }

                if (!string.IsNullOrEmpty(doctor.DoctorProfilePicture))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProfilePicture", doctor.DoctorProfilePicture);
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                doctor.DoctorProfilePicture = fileName;
                _context.SaveChanges();

                return true;
            }

            public string? GetProfilePictureFileName(int userId)
            {
                var doctor = _context.DoctorDetails
                    .AsNoTracking()
                    .SingleOrDefault(d => d.UserId == userId);

                return doctor?.DoctorProfilePicture;
            }
        }
    }

