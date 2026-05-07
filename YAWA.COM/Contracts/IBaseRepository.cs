namespace YAWA.COM.Contracts
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll(string userId);
        Task<T?> GetOne(object id, string userId);
        Task Create(T t, string userId);
        Task Delete(object id, string userId);
        Task Update(object id, object model, string userId);
     
      

    }
}
