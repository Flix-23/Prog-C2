using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Context;
using CvAlInstante.Infrastructure.Core;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Infrastructure.Repositories;

public class SkillRepository : BaseRepository<Skill>, ISkillRepository
{
    public SkillRepository(CvDbContext context) : base(context)
    {
    }
}
