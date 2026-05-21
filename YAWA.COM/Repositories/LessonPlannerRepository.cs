using YAWA.COM.Contracts;
using YAWA.COM.Data;
using Microsoft.EntityFrameworkCore;

namespace YAWA.COM.Repositories
{
    public class LessonPlannerRepository : BaseRepository<LessonPlanner>, ILessonPlannerRepository
    {
        private readonly ApplicationDbContext _db;

        public LessonPlannerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<string>> GetDistinctTitles(string userId)
        {
            return await _db.Set<LessonPlanner>()
                .AsNoTracking()
                .Where(l => l.UserId == userId)
                .Select(l => l.LessonTittle)
                .Distinct()
                .OrderBy(t => t)
                .ToListAsync();
        }
    }
}
