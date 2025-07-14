using BlazorCRUDApp.Shared.Interfaces;
using System.Net.Http.Json;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Client.Services
{
    public class HttpServiceClient : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<T>> GetAsync<T>(string url)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<T>>(url);
            return result!;
        }
    }
}
