using Aipl_Maui_App.Pages;
using Aipl_Maui_App.TabbedPages;
using Aipl_Maui_App.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace Aipl_Maui_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
#if DEBUG
    		builder.Logging.AddDebug();
            
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LogInPageViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

#endif
            return builder.Build();
        }
    }
}
