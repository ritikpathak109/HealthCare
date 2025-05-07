using System.Threading.Tasks;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class PatientProfilePictureService
    {
        private readonly PatientProfilePictureRepository _repository;

        public PatientProfilePictureService(PatientProfilePictureRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> SaveProfilePictureAsync(int userId, string fileName)
        {
            return await _repository.SaveProfilePictureAsync(userId, fileName);
        }

        public async Task<string?> GetProfilePictureFileNameAsync(int userId)
        {
            return await _repository.GetProfilePictureFileNameAsync(userId);
        }

    }
}
