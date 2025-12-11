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
    
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [MaxLength(20)]
    public string? Phone { get; set; }
    
    [MaxLength(100)]
    public string? Location { get; set; }
    
    [MaxLength(200)]
    public string? LinkedIn { get; set; }
    
    [MaxLength(200)]
    public string? Portfolio { get; set; }

    public List<EducationRecordDto> EducationRecords { get; set; } = new();

    public List<WorkExperienceDto> WorkExperiences { get; set; } = new();

    public List<SkillDto> Skills { get; set; } = new();
}
