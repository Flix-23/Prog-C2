using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.Application.Dtos;

public class EducationRecordDto : DtoBase
{
    [Required]
    [MaxLength(200)]
    public string Institution { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public int ResumeId { get; set; }
}
