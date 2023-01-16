global using BlazorEcommerce;
global using BlazorEcommerce.Models;
using BlazorEcommerce.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7077") });
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
