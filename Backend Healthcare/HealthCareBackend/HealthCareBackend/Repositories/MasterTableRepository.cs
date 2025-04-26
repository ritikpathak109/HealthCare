using HealthCareBackend.DTOs;
using HealthCareBackend.Models;

namespace HealthCareBackend.Repositories
{
    public class MasterTableRepository
    {
        private readonly MyDbContext _context;

        public MasterTableRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<CountryDTO> GetCountries()
        {
            return _context.CountryMaster.ToList();
        }

        public List<StateDTO> GetStatesByCountryId(int countryId)
        {
            return _context.StateMaster.Where(s => s.CountryId == countryId).ToList();
        }

        public List<GenderDTO> GetGenders()
        {
            return _context.GenderMaster.ToList();
        }

        public List<RoleDTO> GetRoles()
        {
            return _context.RoleMaster.ToList();
        }
    }

}

