using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Threading;
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

            builder.Services.AddSingleton<LogBase>();
            builder.Services.AddI18nText();

            builder.Services.AddSingleton<Grid>();

            builder.Services.AddBlazorise(option => option.ChangeTextOnKeyPress = true).AddBootstrapProviders().AddFontAwesomeIcons();

            #endregion Singletons


            builder.Services.AddBaseAddressHttpClient();

            var host = builder.Build();

            host.Services.UseBootstrapProviders().UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}