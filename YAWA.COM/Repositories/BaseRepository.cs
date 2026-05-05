using Microsoft.EntityFrameworkCore;
using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : LessonPlanner
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public Task Create(T t, string userId)
        {
           t.UserId= userId;
            _table.Add(t);
            return _db.SaveChangesAsync();
        }

        public async Task Delete(object id, string userId)
        {
            var lessonid = Convert.ToInt32(id);
            var lesson = await _table.FirstOrDefaultAsync(l => l.LessonId == lessonid && l.UserId == userId);
            if (lesson == null)
                return;
            _table.Remove(lesson);
            await _db.SaveChangesAsync();



        }

        public async Task<IEnumerable<T>> GetAll(string userId)
        {
           return await _table.AsNoTracking()
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<T?> GetOne(string id, string userId)
        {
            var lesson = Convert.ToInt32(id);
            return await _table.AsNoTracking()
                .FirstOrDefaultAsync(l => l.LessonId == lesson && l.UserId == userId);  
        }

        public async Task Update(object id, object model, string userId)
        {
            var lessonId = Convert.ToInt32(id);
            var lesson = await _table.FirstOrDefaultAsync(l => l.LessonId == lessonId && l.UserId == userId);
            if (lesson == null)
                return;

            _db.Entry(lesson).CurrentValues.SetValues(model);
            await _db.SaveChangesAsync();
        }
    }
}
