namespace YAWA.COM.Contracts
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll(string userId);
        Task<T?> GetOne(string id, string userId);
        Task<T> Create(T t, string userId);
        Task Delete(object id, string userId);
        Task Update(object id, object model, string userId);
     
      

    }
}
