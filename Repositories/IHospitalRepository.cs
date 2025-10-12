using HospitalApi.models;

namespace HospitalApi.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAllAsync();
        Task<Hospital?> GetByIdAsync(int id);
        Task AddAsync(Hospital hospital);
        Task UpdateAsync(Hospital hospital);
        Task DeleteAsync(Hospital hospital);
        Task<bool> ExistsAsync(int id);
    }
}
