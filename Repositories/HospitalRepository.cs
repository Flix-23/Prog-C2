using HospitalApi.Data;
using HospitalApi.models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext _context;

        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync() =>
            await _context.Hospitals.AsNoTracking().ToListAsync();

        public async Task<Hospital?> GetByIdAsync(int id) =>
            await _context.Hospitals.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);

        public async Task AddAsync(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Hospital hospital)
        {
            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Hospitals.AnyAsync(h => h.Id == id);
    }

}
