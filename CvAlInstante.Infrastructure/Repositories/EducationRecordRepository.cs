using CvAlInstante.Domain.Entities;
using CvAlInstante.Infrastructure.Context;
using CvAlInstante.Infrastructure.Core;
using CvAlInstante.Infrastructure.Interfaces;

namespace CvAlInstante.Infrastructure.Repositories;

public class EducationRecordRepository : BaseRepository<EducationRecord>, IEducationRecordRepository
{
    public EducationRecordRepository(CvDbContext context) : base(context)
    {
    }
}
