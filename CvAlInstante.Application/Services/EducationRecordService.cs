using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;
using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Application.Services;

public class EducationRecordService : BaseService, IEducationRecordService
{
    private readonly IUnitOfWork _unitOfWork;

    public EducationRecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<EducationRecordDto>> CreateAsync(EducationRecordDto dto)
    {
        var resume = await _unitOfWork.Resumes.GetByIdAsync(dto.ResumeId);
        if (resume is null)
            return ServiceResult<EducationRecordDto>.Fail("Resume not found.");

        var entity = new EducationRecord
        {
            Institution = dto.Institution,
            Title = dto.Title,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            ResumeId = dto.ResumeId
        };

        await _unitOfWork.EducationRecords.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        dto.Id = entity.Id;
        return ServiceResult<EducationRecordDto>.Ok(dto);
    }

    public async Task<ServiceResult<IEnumerable<EducationRecordDto>>> GetByResumeAsync(int resumeId)
    {
        var list = await _unitOfWork.EducationRecords.GetAsync(e => e.ResumeId == resumeId);

        var dtoList = list.Select(e => new EducationRecordDto
        {
            Id = e.Id,
            Institution = e.Institution,
            Title = e.Title,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            ResumeId = e.ResumeId
        });

        return ServiceResult<IEnumerable<EducationRecordDto>>.Ok(dtoList);
    }
}
