using BlazorCRUDApp.Shared.Interfaces;
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

        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error retrieving data from {url}: {response.ReasonPhrase}");
            }
            return await response.Content.ReadFromJsonAsync<T>() ?? throw new InvalidOperationException("Response content is null");
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
        public async Task Post<T>(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error posting data to {url}: {response.ReasonPhrase}");
            }
        }
        public
            async Task Put<T>(string url, T data)
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error updating data at {url}: {response.ReasonPhrase}");
            }
        }
        public async Task Delete(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error deleting data at {url}: {response.ReasonPhrase}");
            }
        }

    }
}
