using YAWA.COM.Contracts;
using YAWA.COM.Data;
using Microsoft.EntityFrameworkCore;

namespace YAWA.COM.Repositories
{
    public class LessonPlannerRepository : BaseRepository<LessonPlanner>, ILessonPlannerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<LessonPlanner> _table;

        public LessonPlannerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            _table = _db.Set<LessonPlanner>();
        }

        public async Task<List<LessonPlanner>> GetByTitle(string title, string userId)
        {
            return await _table
                 .Where(x => x.UserId == userId && x.LessonTittle == title)
                 .ToListAsync();
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
