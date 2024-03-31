using Aipl_Maui_App.ViewModel;

namespace Aipl_Maui_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
        }

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
        private void UpdateUserLabels()
        {
            var username = Preferences.Get("UserName", "");
            var Department = Preferences.Get("Department", "");
            var Designation = Preferences.Get("Designation", "");

        }
    }
}
