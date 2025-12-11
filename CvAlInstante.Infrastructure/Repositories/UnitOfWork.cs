using CvAlInstante.Infrastructure.Context;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CvDbContext _context;

    public IResumeRepository Resumes { get; }
    public IEducationRecordRepository EducationRecords { get; }
    public IWorkExperienceRepository WorkExperiences { get; }
    public ISkillRepository Skills { get; }

    public UnitOfWork(
        CvDbContext context,
        IResumeRepository resumes,
        IEducationRecordRepository educationRecords,
        IWorkExperienceRepository workExperiences,
        ISkillRepository skills)
    {
        _context = context;
        Resumes = resumes;
        EducationRecords = educationRecords;
        WorkExperiences = workExperiences;
        Skills = skills;
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
