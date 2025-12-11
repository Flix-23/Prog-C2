using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.API.Models;

public class SkillDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 5)]
    public int Level { get; set; }

    [Required]
    public int ResumeId { get; set; }
}
