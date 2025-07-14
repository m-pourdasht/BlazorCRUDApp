using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Shared.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(User user);
        Task<ServiceResponse<User>> GetByUsername(string username);
    }
}
