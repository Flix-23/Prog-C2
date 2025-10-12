using HospitalApi.dtos.Requests;
using HospitalApi.dtos.Responses;

namespace HospitalApi.Services
{
    public interface IPatientService
    {
        Task<ApiResponse<IEnumerable<PatientResponse>>> GetAllAsync();
        Task<ApiResponse<PatientResponse?>> GetByIdAsync(int id);
        Task<ApiResponse<PatientResponse>> CreateAsync(PatientRequest req);
        Task<ApiResponse<bool>> UpdateAsync(int id, PatientRequest req);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
