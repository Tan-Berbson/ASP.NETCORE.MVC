using Microsoft.EntityFrameworkCore;
using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Repositories
{
    public class MontlyTaskPlan : BaseRepository<MontlyTask>, IMonthlyTaskPlan

    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<MontlyTask> _table;
        public MontlyTaskPlan(ApplicationDbContext db)
        : base(db)
        {
            _db = db;
            _table = db.Set<MontlyTask>();

        }

        public async Task<IEnumerable<MontlyTask>> GetAlltasks(string userId)
        {
          return await _table.Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<MontlyTask>> GetByTitle(string title, string userId)
        {
            return  await _table.Where(x => x.MontlyTaskCategory == title && x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistictTitles(string userId)
        {
           return await _table.AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.MontlyTaskCategory)
                .Distinct()
                .OrderBy(t => t)
                .ToListAsync();
        }

        
    }
}
