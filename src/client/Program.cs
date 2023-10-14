using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using c5m._2d6Dungeon.web;
using c5m._2d6Dungeon;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000/api/") });
builder.Services.AddScoped<ID6Service, D6Service>();

await builder.Build().RunAsync();
