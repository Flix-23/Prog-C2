using HospitalApi.Data;
using HospitalApi.models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() =>
            await _context.Patients.Include(p => p.Hospital).AsNoTracking().ToListAsync();

        public async Task<Patient?> GetByIdAsync(int id) =>
            await _context.Patients.Include(p => p.Hospital).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Patients.AnyAsync(p => p.Id == id);
    }
}
