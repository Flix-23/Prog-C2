using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.Application.Dtos;

public class CreateResumeRequest
{
    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Degree { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? ProfessionalSummary { get; set; }

    public List<EducationRecordDto> EducationRecords { get; set; } = new();

    public List<WorkExperienceDto> WorkExperiences { get; set; } = new();

    public List<SkillDto> Skills { get; set; } = new();
}
