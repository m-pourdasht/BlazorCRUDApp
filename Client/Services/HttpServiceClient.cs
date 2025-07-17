//This layer is located on the client side and its job is to send requests to the API and receive responses.
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
        public async Task<T> Get<T>(string url)
        {
            var result = await _httpClient.GetFromJsonAsync<T>(url);
            return result!;
        }
        public async Task Post<T>(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
        }
        public async Task Put<T>(string url, T data)
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
        }
        public async Task Delete(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
