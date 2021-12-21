using illShop.Client;
using illShop.Shared.BasicServices;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IHttpRequestHandlerService, HttpRequestHandlerService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = false);

await builder.Build().RunAsync();
