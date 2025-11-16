using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.API.Models;

public class WorkExperienceDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Company { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Role { get; set; } = string.Empty;

    [Required]
    [MaxLength(1500)]
    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Required]
    public int ResumeId { get; set; }
}
