using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CobraCoding_APP;
using CobraCoding_APP.Services;
using CobraCoding_APP.Services.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7192/api/") });
builder.Services.AddScoped<ICarService, CarService>();

await builder.Build().RunAsync();

