using HospitalApi.dtos.Requests;
using HospitalApi.dtos.Responses;
using HospitalApi.models;
using HospitalApi.Repositories;

namespace HospitalApi.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repo;

        public HospitalService(IHospitalRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<IEnumerable<HospitalResponse>>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            var data = list.Select(h => new HospitalResponse { Id = h.Id, Name = h.Name, Address = h.Address });
            return ApiResponse<IEnumerable<HospitalResponse>>.Ok(data);
        }

        public async Task<ApiResponse<HospitalResponse?>> GetByIdAsync(int id)
        {
            var h = await _repo.GetByIdAsync(id);
            if (h is null) return ApiResponse<HospitalResponse?>.Fail("Hospital not found");
            var resp = new HospitalResponse { Id = h.Id, Name = h.Name, Address = h.Address };
            return ApiResponse<HospitalResponse?>.Ok(resp);
        }

        public async Task<ApiResponse<HospitalResponse>> CreateAsync(HospitalRequest req)
        {
            var hospital = new Hospital { Name = req.Name, Address = req.Address };
            await _repo.AddAsync(hospital);
            var resp = new HospitalResponse { Id = hospital.Id, Name = hospital.Name, Address = hospital.Address };
            return ApiResponse<HospitalResponse>.Ok(resp, "Created");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int id, HospitalRequest req)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing is null) return ApiResponse<bool>.Fail("Hospital not found");
            existing.Name = req.Name;
            existing.Address = req.Address;
            await _repo.UpdateAsync(existing);
            return ApiResponse<bool>.Ok(true, "Updated");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing is null) return ApiResponse<bool>.Fail("Hospital not found");
            await _repo.DeleteAsync(existing);
            return ApiResponse<bool>.Ok(true, "Deleted");
        }
    }

}
