﻿using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class PatientProfilePictureService
    {
        private readonly PatientProfilePictureRepository _repository;

        public PatientProfilePictureService(PatientProfilePictureRepository repository)
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
