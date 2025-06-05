using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class DoctorProfilePictureService
    {
        private readonly DoctorProfilePictureRepository _repository;

        public DoctorProfilePictureService(DoctorProfilePictureRepository repository)
        {
            _repository = repository;
        }

        public bool SaveProfilePicture(int userId, string fileName)
        {
            return _repository.SaveProfilePicture(userId, fileName);
        }

        public string? GetProfilePictureFileName(int userId)
        {
            return _repository.GetProfilePictureFileName(userId);
        }
    }
}
