using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Core;
using CvAlInstante.Application.Dtos;
using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        // Permitir crear CV sin educación ni experiencia inicialmente
        // if (!request.EducationRecords.Any() && !request.WorkExperiences.Any())
        // {
        //     return ServiceResult<ResumeDto>.Fail("The resume must contain at least one education record or one work experience.");
        // }

        var entity = new Resume
        {
            FullName = request.FullName,
            Degree = request.Degree,
            ProfessionalSummary = request.ProfessionalSummary ?? string.Empty,
            Email = request.Email ?? string.Empty,
            Phone = request.Phone ?? string.Empty,
            Location = request.Location ?? string.Empty,
            LinkedIn = request.LinkedIn ?? string.Empty,
            Portfolio = request.Portfolio ?? string.Empty
        };

        await _unitOfWork.Resumes.AddAsync(entity);
        await _unitOfWork.CompleteAsync();

        // Save Education Records
        if (request.EducationRecords?.Any() == true)
        {
            var educationRecords = request.EducationRecords.Select(e => new EducationRecord
            {
                Institution = e.Institution,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                ResumeId = entity.Id
            }).ToList();

            foreach (var record in educationRecords)
            {
                await _unitOfWork.EducationRecords.AddAsync(record);
            }
            await _unitOfWork.CompleteAsync();
        }

        // Save Work Experiences
        if (request.WorkExperiences?.Any() == true)
        {
            var workExperiences = request.WorkExperiences.Select(w => new WorkExperience
            {
                Company = w.Company,
                Role = w.Role,
                Description = w.Description,
                Achievements = w.Achievements,
                StartDate = w.StartDate,
                EndDate = w.EndDate,
                ResumeId = entity.Id
            }).ToList();

            foreach (var experience in workExperiences)
            {
                await _unitOfWork.WorkExperiences.AddAsync(experience);
            }
            await _unitOfWork.CompleteAsync();
        }

        // Save Skills
        if (request.Skills?.Any() == true)
        {
            var skills = request.Skills.Select(s => new Skill
            {
                Name = s.Name,
                Level = s.Level,
                ResumeId = entity.Id
            }).ToList();

            foreach (var skill in skills)
            {
                await _unitOfWork.Skills.AddAsync(skill);
            }
            await _unitOfWork.CompleteAsync();
        }

        // Reload entity to include related data
        var updatedEntity = await _unitOfWork.Resumes.GetByIdAsync(entity.Id);
        if (updatedEntity is null)
            return ServiceResult<ResumeDto>.Fail("Failed to retrieve created resume.");
        
        var dto = MapToDto(updatedEntity);

        return ServiceResult<ResumeDto>.Ok(dto);
    }

    public async Task<ServiceResult<ResumeDto>> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<ResumeDto>.Fail("Resume not found.");

        var dto = MapToDto(entity);

        return ServiceResult<ResumeDto>.Ok(dto);
    }

    public async Task<ServiceResult<IEnumerable<ResumeDto>>> GetAllAsync()
    {
        var list = await _unitOfWork.Resumes.GetAllAsync();

        var dtoList = list.Select(MapToDto);

        return ServiceResult<IEnumerable<ResumeDto>>.Ok(dtoList);
    }

    public async Task<ServiceResult<ResumeDto>> UpdateAsync(int id, CreateResumeRequest request)
    {
        var entity = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<ResumeDto>.Fail("Resume not found.");

        entity.FullName = request.FullName;
        entity.Degree = request.Degree;
        entity.ProfessionalSummary = request.ProfessionalSummary ?? string.Empty;
        entity.Email = request.Email ?? string.Empty;
        entity.Phone = request.Phone ?? string.Empty;
        entity.Location = request.Location ?? string.Empty;
        entity.LinkedIn = request.LinkedIn ?? string.Empty;
        entity.Portfolio = request.Portfolio ?? string.Empty;

        _unitOfWork.Resumes.Update(entity);
        await _unitOfWork.CompleteAsync();

        // Delete existing related records
        var existingEducation = await _unitOfWork.EducationRecords.GetAsync(e => e.ResumeId == id);
        var existingExperience = await _unitOfWork.WorkExperiences.GetAsync(w => w.ResumeId == id);
        var existingSkills = await _unitOfWork.Skills.GetAsync(s => s.ResumeId == id);

        foreach (var record in existingEducation)
            _unitOfWork.EducationRecords.Delete(record);
        foreach (var exp in existingExperience)
            _unitOfWork.WorkExperiences.Delete(exp);
        foreach (var skill in existingSkills)
            _unitOfWork.Skills.Delete(skill);

        await _unitOfWork.CompleteAsync();

        // Add new related records
        if (request.EducationRecords?.Any() == true)
        {
            var educationRecords = request.EducationRecords.Select(e => new EducationRecord
            {
                Institution = e.Institution,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                ResumeId = entity.Id
            }).ToList();

            foreach (var record in educationRecords)
                await _unitOfWork.EducationRecords.AddAsync(record);
            await _unitOfWork.CompleteAsync();
        }

        if (request.WorkExperiences?.Any() == true)
        {
            var workExperiences = request.WorkExperiences.Select(w => new WorkExperience
            {
                Company = w.Company,
                Role = w.Role,
                Description = w.Description,
                Achievements = w.Achievements,
                StartDate = w.StartDate,
                EndDate = w.EndDate,
                ResumeId = entity.Id
            }).ToList();

            foreach (var experience in workExperiences)
                await _unitOfWork.WorkExperiences.AddAsync(experience);
            await _unitOfWork.CompleteAsync();
        }

        if (request.Skills?.Any() == true)
        {
            var skills = request.Skills.Select(s => new Skill
            {
                Name = s.Name,
                Level = s.Level,
                ResumeId = entity.Id
            }).ToList();

            foreach (var skill in skills)
                await _unitOfWork.Skills.AddAsync(skill);
            await _unitOfWork.CompleteAsync();
        }

        // Reload entity to include related data
        var updatedEntity = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (updatedEntity is null)
            return ServiceResult<ResumeDto>.Fail("Failed to retrieve updated resume.");
        
        var dto = MapToDto(updatedEntity);

        return ServiceResult<ResumeDto>.Ok(dto);
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<bool>.Fail("Resume not found.");

        _unitOfWork.Resumes.Delete(entity);
        await _unitOfWork.CompleteAsync();

        return ServiceResult<bool>.Ok(true);
    }
    
    private ResumeDto MapToDto(Resume entity)
    {
        return new ResumeDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Degree = entity.Degree,
            ProfessionalSummary = entity.ProfessionalSummary,
            Email = entity.Email,
            Phone = entity.Phone,
            Location = entity.Location,
            LinkedIn = entity.LinkedIn,
            Portfolio = entity.Portfolio,
            EducationRecords = entity.EducationRecords?.Select(e => new EducationRecordDto
            {
                Id = e.Id,
                Institution = e.Institution,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                ResumeId = e.ResumeId
            }).ToList() ?? new List<EducationRecordDto>(),
            WorkExperiences = entity.WorkExperiences?.Select(w => new WorkExperienceDto
            {
                Id = w.Id,
                Company = w.Company,
                Role = w.Role,
                Description = w.Description,
                Achievements = w.Achievements,
                StartDate = w.StartDate,
                EndDate = w.EndDate,
                ResumeId = w.ResumeId
            }).ToList() ?? new List<WorkExperienceDto>(),
            Skills = entity.Skills?.Select(s => new SkillDto
            {
                Id = s.Id,
                Name = s.Name,
                Level = s.Level,
                ResumeId = s.ResumeId
            }).ToList() ?? new List<SkillDto>()
        };
    }
}
