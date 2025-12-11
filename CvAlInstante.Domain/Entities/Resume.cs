using CvAlInstante.Domain.Core;

namespace CvAlInstante.Domain.Entities;

public class Resume : BaseEntity
{
    public string FullName { get; set; } = string.Empty;

    public string Degree { get; set; } = string.Empty;

    public string ProfessionalSummary { get; set; } = string.Empty;

    public List<EducationRecord> EducationRecords { get; set; } = new();

    public List<WorkExperience> WorkExperiences { get; set; } = new();

    public List<Skill> Skills { get; set; } = new();
}
