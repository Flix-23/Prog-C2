namespace CvAlInstante.Infrastructure.Services;

public interface IPdfService
{
    byte[] GenerateResumePdf(int resumeId);
}
