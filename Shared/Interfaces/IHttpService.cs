using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Shared.Interfaces
{
    public interface IHttpService
    {
        Task<ServiceResponse<T>> GetAsync<T>(string url);
        Task<T> Get<T>(string url);
        Task Post<T>(string url, T data);
        Task Put<T>(string url, T data);
        Task Delete(string url);
    }
}
