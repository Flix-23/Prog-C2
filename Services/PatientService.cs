using HospitalApi.dtos.Requests;
using HospitalApi.dtos.Responses;
using HospitalApi.models;
using HospitalApi.Repositories;

namespace HospitalApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;
        private readonly IHospitalRepository _hospitalRepo;

        public PatientService(IPatientRepository repo, IHospitalRepository hospitalRepo)
        {
            _repo = repo;
            _hospitalRepo = hospitalRepo;
        }

        public async Task<ApiResponse<IEnumerable<PatientResponse>>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            var data = list.Select(p => MapToResponse(p));
            return ApiResponse<IEnumerable<PatientResponse>>.Ok(data);
        }

        public async Task<ApiResponse<PatientResponse?>> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p is null) return ApiResponse<PatientResponse?>.Fail("Patient not found");
            return ApiResponse<PatientResponse?>.Ok(MapToResponse(p));
        }

        public async Task<ApiResponse<PatientResponse>> CreateAsync(PatientRequest req)
        {
            // Validate hospital exists
            if (!await _hospitalRepo.ExistsAsync(req.HospitalId))
                return ApiResponse<PatientResponse>.Fail("Hospital not found");

            var patient = new Patient
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                BirthDate = req.BirthDate,
                Gender = req.Gender,
                Phone = req.Phone,
                Address = req.Address,
                HospitalId = req.HospitalId
            };

            await _repo.AddAsync(patient);

            var created = MapToResponse(patient);
            return ApiResponse<PatientResponse>.Ok(created, "Created");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(int id, PatientRequest req)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing is null) return ApiResponse<bool>.Fail("Patient not found");

            if (!await _hospitalRepo.ExistsAsync(req.HospitalId))
                return ApiResponse<bool>.Fail("Hospital not found");

            existing.FirstName = req.FirstName;
            existing.LastName = req.LastName;
            existing.BirthDate = req.BirthDate;
            existing.Gender = req.Gender;
            existing.Phone = req.Phone;
            existing.Address = req.Address;
            existing.HospitalId = req.HospitalId;

            await _repo.UpdateAsync(existing);
            return ApiResponse<bool>.Ok(true, "Updated");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing is null) return ApiResponse<bool>.Fail("Patient not found");
            await _repo.DeleteAsync(existing);
            return ApiResponse<bool>.Ok(true, "Deleted");
        }

        private PatientResponse MapToResponse(models.Patient p) =>
            new PatientResponse
            {
                Id = p.Id,
                FullName = $"{p.FirstName} {p.LastName}",
                Age = DateTime.Now.Year - p.BirthDate.Year,
                Gender = p.Gender,
                Phone = p.Phone,
                Address = p.Address,
                HospitalId = p.HospitalId,
                HospitalName = p.Hospital?.Name ?? string.Empty
            };
    }
}
