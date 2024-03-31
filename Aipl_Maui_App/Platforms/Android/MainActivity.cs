using Aipl_Maui_App.Repository;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Aipl_Maui_App
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            GoToMainPage();
        }

        private async void GoToMainPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");  
        }
    }
}
