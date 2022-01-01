﻿using System.Text.Json;
using System.Net.Http.Json;
using illShop.Shared.BasicObjects.Paging;
using Microsoft.AspNetCore.WebUtilities;
using illShop.Shared.Dto.DtosRelatedProduct;
using System.Text;
using illShop.Shared.Dto.DtosRelatedIdentity;

namespace illShop.Shared.BasicServices
{
    public interface IHttpRequestHandlerService
    {
        #region common

        Task<bool> PostAsHttpJsonAsync(object Dto, string uriAddress);
        Task<List<T>> GetListData<T>(string uriAddress);
        Task<string> UploadImage(MultipartFormDataContent content, string uriAddress);
        Task<T> GetById<T>(int id, string uriAddress);
        Task<bool> UpdateByDto(object data, string uriAddress);
        Task<bool> DeleteById(int id, string uriAddress);

        #endregion

        #region pagination

        Task<PagingResponse<ProductDto>> GetPagedData(PagingParameters pagingParameters, string uriAddress);
        Task<PagingResponse<UserDetailDto>> GetPagedUserData(PagingParameters pagingParameters, string uriAddress);
        Task<PagingResponse<ProductCategoryDto>> GetPagedProductCategory(PagingParameters pagingParameters, string uriAddress);

        #endregion
    }

    public class HttpRequestHandlerService : IHttpRequestHandlerService
    {
        #region DI / Ctor
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public HttpRequestHandlerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        #endregion

        #region common
        public async Task<bool> PostAsHttpJsonAsync(object Dto, string uriAddress)
        {
            bool isdone = false;
            var responseMessage = await _httpClient.PostAsJsonAsync(uriAddress, Dto);
            if (responseMessage.IsSuccessStatusCode)
                isdone = true;
            return isdone;
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
                var imgUrl = Path.Combine(_httpClient.BaseAddress.ToString(), postContent);
                return imgUrl;
            }
        }

        public async Task<T> GetById<T>(int id, string uriAddress)
        {
            var url = Path.Combine(uriAddress, id.ToString());
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var dto = JsonSerializer.Deserialize<T>(content, _options);
            return dto;
        }

        public async Task<bool> UpdateByDto(object data, string uriAddress)
        {
            bool isdone = false;
            var content = JsonSerializer.Serialize(data);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var putResult = await _httpClient.PutAsync(uriAddress, bodyContent);
           // var putContent = await putResult.Content.ReadAsStringAsync();
            if (putResult.IsSuccessStatusCode)
                isdone = true;
            return isdone;
        }

        public async Task<bool> DeleteById(int id, string uriAddress)
        {
            var isDnoe = false;
            var url = Path.Combine(uriAddress, id.ToString());
            var deleteResult = await _httpClient.DeleteAsync(url);
            //var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (deleteResult.IsSuccessStatusCode)
                isDnoe = true;
            return isDnoe;
        }

        public async Task<List<T>> GetListData<T>(string uriAddress)
        {
            var response = await _httpClient.GetAsync(uriAddress);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var dto = JsonSerializer.Deserialize<List<T>>(content, _options);
            return dto;
        }
        #endregion

        #region pagination

        public async Task<PagingResponse<ProductDto>> GetPagedData(PagingParameters pagingParameters, string uriAddress)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["searchTerm"] = pagingParameters.SearchTerm ?? "",
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

        public async Task<PagingResponse<UserDetailDto>> GetPagedUserData(PagingParameters pagingParameters, string uriAddress)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["searchTerm"] = pagingParameters.SearchTerm ?? "",
                ["orderBy"] = pagingParameters.OrderBy
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(uriAddress, queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<UserDetailDto>
            {
                Items = JsonSerializer.Deserialize<List<UserDetailDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

        public async Task<PagingResponse<ProductCategoryDto>> GetPagedProductCategory(PagingParameters pagingParameters, string uriAddress)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["searchTerm"] = pagingParameters.SearchTerm ?? "",
                ["orderBy"] = pagingParameters.OrderBy
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(uriAddress, queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<ProductCategoryDto>
            {
                Items = JsonSerializer.Deserialize<List<ProductCategoryDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

        #endregion
    }
}
