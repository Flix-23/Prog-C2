using CvAlInstante.Domain.Core;

namespace CvAlInstante.Domain.Entities;

public class EducationRecord : BaseEntity
{
    public string Institution { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ResumeId { get; set; }

    public Resume? Resume { get; set; }
}
