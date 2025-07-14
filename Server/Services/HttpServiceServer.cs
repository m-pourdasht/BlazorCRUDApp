using BlazorCRUDApp.Shared.Interfaces;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Http.Json;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Server.Services
{
    public class HttpServiceServer : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpServiceServer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ServiceResponse<T>> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<T>>();
            return result ?? new ServiceResponse<T>
            {
                Success = false,
                Message = "Error retrieving data"
            };

        }
    }
}
