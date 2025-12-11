namespace CvAlInstante.API.Models;

public class ResumeDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string ProfessionalSummary { get; set; } = string.Empty;
}
