using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;

namespace CvAlInstante.Application.Contract;

public interface ISkillService : IBaseService
{
    Task<ServiceResult<SkillDto>> CreateAsync(SkillDto dto);
    Task<ServiceResult<IEnumerable<SkillDto>>> GetByResumeAsync(int resumeId);
}
