using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.API.Models;

public class CreateResumeRequest
{
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Degree { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? ProfessionalSummary { get; set; }
}
