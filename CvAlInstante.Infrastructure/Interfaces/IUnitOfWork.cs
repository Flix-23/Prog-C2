namespace CvAlInstante.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IResumeRepository Resumes { get; }
    IEducationRecordRepository EducationRecords { get; }
    IWorkExperienceRepository WorkExperiences { get; }
    ISkillRepository Skills { get; }

    Task<int> CompleteAsync();
}
