using System.ComponentModel.DataAnnotations;

namespace CvAlInstante.Application.Dtos;

public class SkillDto : DtoBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 5)]
    public int Level { get; set; }

    [Required]
    public int ResumeId { get; set; }
}
