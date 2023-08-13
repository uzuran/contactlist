using ContactList.Models;
using ContactList.Pages;
using ContactList.ViewModel;
using ContactList.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Reflection;

namespace ContactList;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


        /// ViewModels
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<SignUpViewModel>();

        /// Views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<SignUpPage>();


        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<UserDataContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
