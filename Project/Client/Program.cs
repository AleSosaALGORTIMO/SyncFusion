using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Project.Client;
using Project.Client.Helpers;
using Project.Client.Repositorios;





using Syncfusion.Blazor;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using MudBlazor.Services;
using System.Globalization;

var cultureDefault = new CultureInfo("fr-FR");
CultureInfo.DefaultThreadCurrentCulture = cultureDefault;
CultureInfo.DefaultThreadCurrentUICulture = cultureDefault;



//using WeatherForecastService = BlazorNet5Samples.Client.Data.WeatherForecastService;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjczNzM0QDMyMzAyZTMyMmUzMFdBNWRwTWNlUEVQRFpieFRaSjk0Vjc1bUNhL2dPNFN5VFVUNlVHZEQ1c1E9");
    
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });


builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddMudServices();


builder.Services.AddScoped<IRepositorio, Repositorio>();

builder.Services.AddScoped<IMostrarMensajes, MostrarMensajes>();

builder.Services.AddScoped<IMostrarMensajes, MostrarMensajes>();


await builder.Build().RunAsync();




