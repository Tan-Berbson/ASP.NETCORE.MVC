using YAWA.COM.Contracts;
using YAWA.COM.Data;

namespace YAWA.COM.Repositories
{
    public class MontlyTaskPlan : BaseRepository<MontlyTask>, IMonthlyTaskPlan

    {
        public MontlyTaskPlan(ApplicationDbContext db)
        : base(db)
        {

        }

}
}
