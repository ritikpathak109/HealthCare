using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class GetMedicinesService
    {

        private readonly GetMedicinesRepository _medicineRepository;
        public GetMedicinesService(GetMedicinesRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public List<MedicinesDTO> GetMedicine()
        {
            return _medicineRepository.GetMedicines();
        }
    }

}
