using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebAssemblyApp.Client.ViewModels;
using WebAssemblyApp.Client.ViewModels.Contracts;
using WebAssemblyApp.ViewModels;

namespace WebAssemblyApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            AddHttpClients(builder, builder.Configuration);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Radzen
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            await builder.Build().RunAsync();
        }

        public static void AddHttpClients(WebAssemblyHostBuilder builder, IConfiguration configuration)
        {
            // string baseAddress = configuration["BaseAddress"];

            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            builder.Services.AddHttpClient<ILoginViewModel, LoginViewModel>
                ("LoginViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<IRegisterViewModel, RegisterViewModel>
                ("RegisterViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<IProductViewModel, ProductViewModel>
                   ("ProductViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient< ICatalogViewModel, CatalogViewModel>
                  ("CatalogViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<IRadzenViewModel, RadzenViewModel>
                 ("RadzenViewModelClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            //builder.Services.AddHttpClient<ISettingsViewModel, SettingsViewModel>
            //    ("SettingsViewModelClient", client => client.BaseAddress = new Uri(baseAddress))
            //    .AddHttpMessageHandler<CustomAuthorizationHandler>();

            //builder.Services.AddHttpClient<IAssignRolesViewModel, AssignRolesViewModel>
            //    ("AssignRolesViewModel", client => client.BaseAddress = new Uri(baseAddress))
            //    .AddHttpMessageHandler<CustomAuthorizationHandler>();


        }
    }
}
