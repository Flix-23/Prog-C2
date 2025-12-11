using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Context;
using CvAlInstante.Infrastructure.Core;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Infrastructure.Repositories;

public class WorkExperienceRepository : BaseRepository<WorkExperience>, IWorkExperienceRepository
{
    public WorkExperienceRepository(CvDbContext context) : base(context)
    {
    }
}
