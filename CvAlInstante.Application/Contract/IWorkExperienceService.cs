using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;

namespace CvAlInstante.Application.Contract;

public interface IWorkExperienceService : IBaseService
{
    Task<ServiceResult<WorkExperienceDto>> CreateAsync(WorkExperienceDto dto);
    Task<ServiceResult<IEnumerable<WorkExperienceDto>>> GetByResumeAsync(int resumeId);
}
