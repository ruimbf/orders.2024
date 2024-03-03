using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Orders.Frontend;
using Orders.Frontend.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// .NEW
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7216/") });

builder.Services.AddScoped<IRepository, Repository>();

// end.NEW



await builder.Build().RunAsync();
