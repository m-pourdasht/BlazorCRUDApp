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

        public System.Threading.Tasks.Task Delete(string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string url)
        {
            throw new NotImplementedException();
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
        public
            async System.Threading.Tasks.Task Post<T>(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error posting data to {url}: {response.ReasonPhrase}");
            }
        }
        public
            async System.Threading.Tasks.Task Put<T>(string url, T data)
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error updating data at {url}: {response.ReasonPhrase}");
            }
        }
    }
}
