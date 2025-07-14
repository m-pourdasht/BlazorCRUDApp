namespace BlazorCRUDApp.Server.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GelAll();
        Task<T?> GetById(int id);
        Task Add (T entity);
        void Delete(T entity);
        Task Save();
    }
}
