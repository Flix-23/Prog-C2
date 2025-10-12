using HospitalApi.dtos.Requests;
using HospitalApi.dtos.Responses;

namespace HospitalApi.Services
{
   public interface IHospitalService
{
    Task<ApiResponse<IEnumerable<HospitalResponse>>> GetAllAsync();
    Task<ApiResponse<HospitalResponse?>> GetByIdAsync(int id);
    Task<ApiResponse<HospitalResponse>> CreateAsync(HospitalRequest req);
    Task<ApiResponse<bool>> UpdateAsync(int id, HospitalRequest req);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
}
