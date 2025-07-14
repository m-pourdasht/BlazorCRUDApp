using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Server.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAll();
        Task<User> GetByUsernameAsync(string username);
        Task<User?> GetUserById(int id);

    }
}
