using YAWA.COM.Data;

namespace YAWA.COM.Contracts
{
    public interface ILessonPlannerRepository : IBaseRepository<LessonPlanner>
    {
        Task<IEnumerable<string>> GetDistinctTitles(string userId);
        Task<List<LessonPlanner>>GetByTitle(string title, string userId);
    }
}
