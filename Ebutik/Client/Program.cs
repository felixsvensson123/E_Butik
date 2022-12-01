global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Authorization;
global using System.Net.Http.Json;
global using BlazorEcom.Shared;
global using Blazored.LocalStorage;
global using BlazorEcom.Client;
global using BlazorEcom.Client.Services;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
await builder.Build().RunAsync();
