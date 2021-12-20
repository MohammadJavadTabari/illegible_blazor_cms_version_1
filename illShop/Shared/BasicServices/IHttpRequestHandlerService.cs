using System.Text.Json;
using System.Net.Http.Json;
using illShop.Shared.BasicObjects.Paging;
using Microsoft.AspNetCore.WebUtilities;
using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Shared.BasicServices
{
    public interface IHttpRequestHandlerService
    {
        Task<bool> PostAsHttpJsonAsync(object Dto, string uriAddress);
        Task<PagingResponse<ProductDto>> GetPagedData(PagingParameters pagingParameters, string uriAddress);
        Task<string> UploadImage(MultipartFormDataContent content, string uriAddress);
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
        public async Task<PagingResponse<ProductDto>> GetPagedData(PagingParameters pagingParameters, string uriAddress)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["searchTerm"] = pagingParameters.SearchTerm == null ? "" : pagingParameters.SearchTerm,
                ["orderBy"] = pagingParameters.OrderBy
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(uriAddress, queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<ProductDto>
            {
                Items = JsonSerializer.Deserialize<List<ProductDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

        public async Task<string> UploadImage(MultipartFormDataContent content, string uriAddress)
        {
            var postResult = await _httpClient.PostAsync(uriAddress, content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine(uriAddress, postContent);
                return imgUrl;
            }
        }
    }
}
