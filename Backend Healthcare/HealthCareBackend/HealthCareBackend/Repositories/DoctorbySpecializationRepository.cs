using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using static HealthCareBackend.DTOs.DoctorBySpecializationDTO;

namespace HealthCareBackend.Repositories
{
    public class DoctorbySpecializationRepository
    {
        private readonly MyDbContext _context;

        public DoctorbySpecializationRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<DoctorBySpecializationDTO> GetDoctorsBySpecializationId(int specializationId)
        {
            return _context.DoctorDetails.Where(d => d.SpecializationId == specializationId && d.IsDeleted == 0 && d.IsActive == 1)
                .Select(d => new DoctorBySpecializationDTO
                {
                    DoctorId = d.DoctorId,
                    DoctorFullName = d.DoctorFirstName + " " + d.DoctorLastName,
                    SpecializationId = d.SpecializationId
                })
                .ToList();
        }
    }
}
