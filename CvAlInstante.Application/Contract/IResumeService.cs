using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;

namespace CvAlInstante.Application.Contract;

public interface IResumeService : IBaseService
{
    Task<ServiceResult<ResumeDto>> CreateAsync(CreateResumeRequest request);
    Task<ServiceResult<ResumeDto>> GetByIdAsync(int id);
    Task<ServiceResult<IEnumerable<ResumeDto>>> GetAllAsync();
    Task<ServiceResult<ResumeDto>> UpdateAsync(int id, CreateResumeRequest request);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}
