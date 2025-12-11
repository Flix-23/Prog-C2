using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.Application.Dtos;

public class ResumeDto : DtoBase
{
    [Required]
    [MaxLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Degree { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string ProfessionalSummary { get; set; } = string.Empty;
}
