using YAWA.COM.Data;

namespace YAWA.COM.Contracts
{
    public interface IMonthlyTaskPlan : IBaseRepository<MontlyTask>
{
        Task<IEnumerable<string>> GetDistictTitles(string userId);
        Task<List<MontlyTask>> GetByTitle(string title, string userId);

        Task<IEnumerable<MontlyTask>> GetAlltasks(string userId);
        Task UpdateMontly(MontlyTask model,string userId);

    }
}
