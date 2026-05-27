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
            return  await _table.Where(x => x.DailyTaskName == title && x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistictTitles(string userId)
        {
           return await _table.AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.DailyTaskName)
                .Distinct()
                .OrderBy(t => t)
                .ToListAsync();
        }

        public async Task UpdateMontly(MontlyTask model, string userId)
        {
            // ✅ No AsNoTracking — EF watches this entity
            var entity = await _table
                .FirstOrDefaultAsync(e => e.Id == model.Id && e.UserId == userId);

            if (entity == null)
                return;

            // ✅ Manually assign each field — clear and safe
            entity.MontlyTaskCategory = model.MontlyTaskCategory;
            entity.DailyTaskName = model.DailyTaskName;
            entity.TaskStatus = model.TaskStatus;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;

            await _db.SaveChangesAsync(); // ✅ EF sees the changes and saves
        }
    }
}
