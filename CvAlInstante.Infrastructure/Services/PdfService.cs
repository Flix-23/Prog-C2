using System;
using System.Linq;
using System.Threading.Tasks;
using CvAlInstante.Infrastructure.Context;
using CvAlInstante.Infrastructure.Services;

namespace CvAlInstante.Infrastructure.Services;

public class PdfService : IPdfService
{
    private readonly CvDbContext _context;

    public PdfService(CvDbContext context)
    {
        _context = context;
    }

    public byte[] GenerateResumePdf(int resumeId)
    {
        // Here you would load the resume + related data and build a PDF.
        // For now we just return an empty byte array to keep the project compiling.
        var resume = _context.Resumes.FirstOrDefault(x => x.Id == resumeId);
        if (resume is null)
        {
            throw new InvalidOperationException("Resume not found.");
        }

        return Array.Empty<byte>();
    }
}
