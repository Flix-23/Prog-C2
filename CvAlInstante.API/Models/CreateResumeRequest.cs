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
    
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Location { get; set; }
    public string? LinkedIn { get; set; }
    public string? Portfolio { get; set; }
}
