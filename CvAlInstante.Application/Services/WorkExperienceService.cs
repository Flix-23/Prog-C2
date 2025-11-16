using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;
using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Application.Services;

public class WorkExperienceService : BaseService, IWorkExperienceService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkExperienceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<WorkExperienceDto>> CreateAsync(WorkExperienceDto dto)
    {
        var resume = await _unitOfWork.Resumes.GetByIdAsync(dto.ResumeId);
        if (resume is null)
            return ServiceResult<WorkExperienceDto>.Fail("Resume not found.");

        var entity = new WorkExperience
        {
            Company = dto.Company,
            Role = dto.Role,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate ?? dto.StartDate,
            ResumeId = dto.ResumeId
        };

        await _unitOfWork.WorkExperiences.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        dto.Id = entity.Id;
        return ServiceResult<WorkExperienceDto>.Ok(dto);
    }

    public async Task<ServiceResult<IEnumerable<WorkExperienceDto>>> GetByResumeAsync(int resumeId)
    {
        var list = await _unitOfWork.WorkExperiences.GetAsync(w => w.ResumeId == resumeId);

        var dtoList = list.Select(w => new WorkExperienceDto
        {
            Id = w.Id,
            Company = w.Company,
            Role = w.Role,
            Description = w.Description,
            StartDate = w.StartDate,
            EndDate = w.EndDate,
            ResumeId = w.ResumeId
        });

        return ServiceResult<IEnumerable<WorkExperienceDto>>.Ok(dtoList);
    }
}
