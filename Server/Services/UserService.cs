using BlazorCRUDApp.Server.UnitOfWork;
using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ServiceResponse<User>> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<User>> Register(User user)
        {
            return new ServiceResponse<User>
            {
                Data = user,
                Message = "User registered successfully"
            };
        }

    }
}
