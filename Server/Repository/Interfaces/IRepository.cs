namespace BlazorCRUDApp.Server.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        Task<T?> GetById(int id);
        Task Add(T entity);
        void Delete(T entity);
        Task Save();
    }
}
