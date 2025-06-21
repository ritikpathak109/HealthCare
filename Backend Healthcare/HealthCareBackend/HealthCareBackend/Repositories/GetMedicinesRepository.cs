using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class GetMedicinesRepository
    {
        private readonly MyDbContext _context;

        public GetMedicinesRepository(MyDbContext context)
        {
            _context = context;
        }


        public List<MedicinesDTO> GetMedicines()
        {
            return _context.USP_GetAvailableMedicinesForDoctor.FromSqlRaw("EXEC USP_GetAvailableMedicinesForDoctor").ToList();

        }


    }
}
