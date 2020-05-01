using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;
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

            //builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); //Http
            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton<LogBase>(); //Log singleton
            builder.Services.AddI18nText(); //Localizer singleton
            builder.Services.AddSingleton<Grid>(); //Network singleton
            builder.Services.AddSingleton<ResultCalc>();
            builder.Services.AddBlazorise(option => option.ChangeTextOnKeyPress = true) //Tables singleton
                            .AddBootstrapProviders()
                            .AddFontAwesomeIcons();            
            #endregion Singletons

            var host = builder.Build();

            host.Services.UseBootstrapProviders().UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}