using Microsoft.EntityFrameworkCore;
using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }
        public Task<T> Create(T t, string userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(object id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetOne(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(object id, object model, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
