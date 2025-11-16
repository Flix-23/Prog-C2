using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;
using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Application.Services;

public class ResumeService : BaseService, IResumeService
{
    private readonly IUnitOfWork _unitOfWork;

    public ResumeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<ResumeDto>> CreateAsync(CreateResumeRequest request)
    {
        if (!request.EducationRecords.Any() && !request.WorkExperiences.Any())
        {
            return ServiceResult<ResumeDto>.Fail("The resume must contain at least one education record or one work experience.");
        }

        var entity = new Resume
        {
            FullName = request.FullName,
            Degree = request.Degree,
            ProfessionalSummary = request.ProfessionalSummary ?? string.Empty
        };

        await _unitOfWork.Resumes.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        var dto = new ResumeDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Degree = entity.Degree,
            ProfessionalSummary = entity.ProfessionalSummary
        };

        return ServiceResult<ResumeDto>.Ok(dto);
    }

    public async Task<ServiceResult<ResumeDto>> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<ResumeDto>.Fail("Resume not found.");

        var dto = new ResumeDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Degree = entity.Degree,
            ProfessionalSummary = entity.ProfessionalSummary
        };

        return ServiceResult<ResumeDto>.Ok(dto);
    }

    public async Task<ServiceResult<IEnumerable<ResumeDto>>> GetAllAsync()
    {
        var list = await _unitOfWork.Resumes.GetAllAsync();

        var dtoList = list.Select(r => new ResumeDto
        {
            Id = r.Id,
            FullName = r.FullName,
            Degree = r.Degree,
            ProfessionalSummary = r.ProfessionalSummary
        });

        return ServiceResult<IEnumerable<ResumeDto>>.Ok(dtoList);
    }
}
