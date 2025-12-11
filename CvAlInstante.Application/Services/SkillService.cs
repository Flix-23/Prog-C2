using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;
using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Application.Services;

public class SkillService : BaseService, ISkillService
{
    private readonly IUnitOfWork _unitOfWork;

    public SkillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<SkillDto>> CreateAsync(SkillDto dto)
    {
        var resume = await _unitOfWork.Resumes.GetByIdAsync(dto.ResumeId);
        if (resume is null)
            return ServiceResult<SkillDto>.Fail("Resume not found.");

        var entity = new Skill
        {
            Name = dto.Name,
            Level = dto.Level,
            ResumeId = dto.ResumeId
        };

        await _unitOfWork.Skills.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        dto.Id = entity.Id;
        return ServiceResult<SkillDto>.Ok(dto);
    }

    public async Task<ServiceResult<IEnumerable<SkillDto>>> GetByResumeAsync(int resumeId)
    {
        var list = await _unitOfWork.Skills.GetAsync(s => s.ResumeId == resumeId);

        var dtoList = list.Select(s => new SkillDto
        {
            Id = s.Id,
            Name = s.Name,
            Level = s.Level,
            ResumeId = s.ResumeId
        });

        return ServiceResult<IEnumerable<SkillDto>>.Ok(dtoList);
    }
}
