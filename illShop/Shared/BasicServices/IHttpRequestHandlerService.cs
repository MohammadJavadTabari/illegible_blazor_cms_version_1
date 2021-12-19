using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace illShop.Shared.BasicServices
{
    public interface IHttpRequestHandlerService
    {
        Task<bool> PostAsHttpJsonAsync(object Dto, string uriAddress);
    }
    public class HttpRequestHandlerService : IHttpRequestHandlerService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public HttpRequestHandlerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<bool> PostAsHttpJsonAsync(object Dto, string uriAddress)
        {
            bool isdone = false;
            var responseMessage = await _httpClient.PostAsJsonAsync(uriAddress, Dto);
            if (responseMessage.IsSuccessStatusCode)
                isdone = true;
            return isdone;
        }
    }
}
