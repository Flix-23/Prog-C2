using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.Application.Dtos;

public class WorkExperienceDto : DtoBase
{
    [Required]
    [MaxLength(200)]
    public string Company { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Role { get; set; } = string.Empty;

    [Required]
    [MaxLength(1500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(1500)]
    public string Achievements { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public int ResumeId { get; set; }
}
