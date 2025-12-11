using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Context;
using CvAlInstante.Infrastructure.Core;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Infrastructure.Repositories;

public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
{
    public ResumeRepository(CvDbContext context) : base(context)
    {
    }
}
