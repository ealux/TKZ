using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;
using TKZ.Client.Shared.Header;
using TKZ.Shared;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace TKZ.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");


            #region Singletons

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); //Http
            //builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton<LogBase>(); //Log singleton
            builder.Services.AddSingleton<GridService>(); //GridService singleton
            builder.Services.AddI18nText(); //Localizer singleton
            //builder.Services.AddSingleton<Grid>(); //Network singleton
            builder.Services.AddBlazorise(option => option.ChangeTextOnKeyPress = true) //Tables singleton
                            .AddBootstrapProviders()
                            .AddFontAwesomeIcons();
            builder.Services.AddHotKeys();

            #endregion Singletons
            

            var host = builder.Build();

            host.Services.UseBootstrapProviders().UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}