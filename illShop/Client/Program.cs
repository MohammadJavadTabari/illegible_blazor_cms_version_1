using Blazored.LocalStorage;
using illShop.Client;
using illShop.Shared.BasicServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IHttpRequestHandlerService, HttpRequestHandlerService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = false);
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider,ApiAuthenticationStateProvider>();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
