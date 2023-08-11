using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        builder.Services.AddDbContext<UserDataContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("Default").ToString(), 
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default").ToString())));
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
