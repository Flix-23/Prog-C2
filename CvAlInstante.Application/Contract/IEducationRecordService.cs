using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;

namespace CvAlInstante.Application.Contract;

public interface IEducationRecordService : IBaseService
{
    Task<ServiceResult<EducationRecordDto>> CreateAsync(EducationRecordDto dto);
    Task<ServiceResult<IEnumerable<EducationRecordDto>>> GetByResumeAsync(int resumeId);
}
