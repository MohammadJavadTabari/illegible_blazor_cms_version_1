using Blazored.LocalStorage;
using illShop.Shared.Dto.DtosRelatedIdentity;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace illShop.Shared.BasicServices
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<LoginResultDto> Login(LoginModelDto loginModel);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        // i use ILocalStorageService(it's a nuget) here
        // to get or set user token's
        private readonly ILocalStorageService _localStorage;
        public AuthenticationService(HttpClient client, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }
        public async Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var content = JsonSerializer.Serialize(userForRegistration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var registrationResult = await _client.PostAsync("AccountHandelMethods/Registration", bodyContent);
            var registrationContent = await registrationResult.Content.ReadAsStringAsync();
            if (!registrationResult.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, _options);
                return result;
            }
            return new RegistrationResponseDto { IsSuccessfulRegistration = true };
        }
        // get user login data and validate it
        public async Task<LoginResultDto> Login(LoginModelDto loginModel)
        {
            // like register method i serialize loginViewModel
            // to json
            var loginAsJson = JsonSerializer.Serialize(loginModel);

            // then like register method
            // send jsonLoginDto to login controller Encoded in utf8
            //and get response
            var response = await _client.PostAsync("LoginHandler/login", new StringContent(loginAsJson,Encoding.UTF8, "application/json"));

            // then deserialize response to LoginDto
            var loginResult = JsonSerializer.Deserialize<LoginResultDto>
                (await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // in case of invalid authentication data send it back 
            // for showing errors
            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            // as i said above i use local storage here
            // to get or set token's
            await _localStorage.SetItemAsync("authToken", loginResult.Token);

            // Mark User As Authenticated 
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);

            // set http Authorization req header with bearer scheme
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            // remove Authentication Generated Token 
            await _localStorage.RemoveItemAsync("authToken");

            // Mark User As Logged Out
            ((ApiAuthenticationStateProvider)
                _authenticationStateProvider)
                .MarkUserAsLoggedOut();

            // remove http Authorization req header
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
