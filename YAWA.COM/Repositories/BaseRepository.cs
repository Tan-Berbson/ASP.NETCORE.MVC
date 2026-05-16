using Microsoft.EntityFrameworkCore;
using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
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
            t.UserId = userId;
            _table.Add(t);
            return _db.SaveChangesAsync();
        }

        public async Task Delete(object id, string userId)
        {
            var entityId = Convert.ToInt32(id);
            var entity = await _table.FirstOrDefaultAsync(e => e.Id == entityId && e.UserId == userId);
            if (entity == null)
                return;
            _table.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll(string userId)
        {
            return await _table.AsNoTracking()
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<T?> GetOne(object id, string userId)
        {
            var entityId = Convert.ToInt32(id);
            return await _table.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == entityId && e.UserId == userId);
        }

        public async Task Update(object id, object model, string userId)
        {
            var entityId = Convert.ToInt32(id);
            var entity = await _table.FirstOrDefaultAsync(e => e.Id == entityId && e.UserId == userId);
            if (entity == null)
                return;

            _db.Entry(entity).CurrentValues.SetValues(model);
            await _db.SaveChangesAsync();
        }
    }
}
