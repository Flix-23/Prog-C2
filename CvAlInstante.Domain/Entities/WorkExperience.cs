using System;
using CvAlInstante.Domain.Core;

namespace CvAlInstante.Domain.Entities;

public class WorkExperience : BaseEntity
{
    public string Company { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Achievements { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int ResumeId { get; set; }

    public Resume? Resume { get; set; }
}
