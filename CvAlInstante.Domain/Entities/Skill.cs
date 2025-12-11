using CvAlInstante.Domain.Core;

namespace CvAlInstante.Domain.Entities;

public class Skill : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // 1 = Basic, 5 = Expert
    public int Level { get; set; }

    public int ResumeId { get; set; }

    public Resume? Resume { get; set; }
}
