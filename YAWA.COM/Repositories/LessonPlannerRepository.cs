using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Repositories
{
    public class LessonPlannerRepository : BaseRepository<LessonPlanner>, ILessonPlannerRepository
    {
        public LessonPlannerRepository(ApplicationDbContext db) : base(db)
        {
        }

    }
}
