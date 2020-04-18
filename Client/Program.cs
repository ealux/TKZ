using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;

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

            #endregion Singletons

            #region Localization

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ru-RU"),
            };

            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");
            //CultureInfo.CurrentCulture = new CultureInfo("ru_RU");
            
            #endregion Localization

            builder.Services.AddBaseAddressHttpClient();

            await builder.Build().RunAsync();
        }
    }
}