using YAWA.COM.Contracts;
using YAWA.COM.Data;
using YAWA.Data;

namespace YAWA.COM.Repositories
{
    public class IponRepository : BaseRepository<Ipon>, IIponRepository
{
        public IponRepository(ApplicationDbContext db) : base(db)
        {

        }
}
}
