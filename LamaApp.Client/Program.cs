using LamaApp.Client;
using LamaApp.Client.Services;
using LamaApp.Client.Services.Capitulos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5132") });

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICapituloService, CapituloService>();

await builder.Build().RunAsync();
