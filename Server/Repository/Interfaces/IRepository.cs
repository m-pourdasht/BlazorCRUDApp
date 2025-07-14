namespace BlazorCRUDApp.Server.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAllAsync();
    }
}
