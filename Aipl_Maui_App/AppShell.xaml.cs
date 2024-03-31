using Aipl_Maui_App.Pages;
using Aipl_Maui_App.TabbedPages;
using Aipl_Maui_App.ViewModel;

namespace Aipl_Maui_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {

            InitializeComponent();
            this.BindingContext = new SignOutViewModel();
            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(MyTabbedPage), typeof(MyTabbedPage));
            Routing.RegisterRoute(nameof(New_Call_Page), typeof(New_Call_Page));
            Routing.RegisterRoute(nameof(Inspect_Calls), typeof(Inspect_Calls));
            Routing.RegisterRoute(nameof(ReportPage), typeof(ReportPage));

            MessagingCenter.Subscribe<LoginPage>(this, "UpdateUserLabels", (sender) =>
            {
                UpdateUserLabels();
            });
        }

        private void UpdateUserLabels()
        {
            var username = Preferences.Get("UserName", "");
            var Department = Preferences.Get("Department", "");
            var Designation = Preferences.Get("Designation", "");
            var User_ID = Preferences.Get("UserId", "");

            lbluserName.Text = !string.IsNullOrEmpty(username) ? username : "No Data";
            lblDepartment.Text = !string.IsNullOrEmpty(Department) ? Department : "No Data";
            lblDesignation.Text = !string.IsNullOrEmpty(Designation) ? Designation : "No Data";

            ShellContent tabAccepted = (ShellContent)Shell.Current.FindByName("Tab_AcceptedCalls");
            ShellContent tabRejected = (ShellContent)Shell.Current.FindByName("Tab_RejectedCalls");
            ShellContent tabRaised = (ShellContent)Shell.Current.FindByName("Tab_RaisedCalls");
            ShellContent tabNewRaising = (ShellContent)Shell.Current.FindByName("Tab_NewCall");

            if (Department == "Production" )
            {
                if (tabRaised != null)
                    tabRaised.IsVisible = false;
                if (tabNewRaising != null)
                    tabNewRaising.IsVisible = true;
                if (tabAccepted != null)
                    tabAccepted.IsVisible = false;
                if (tabRejected != null)
                    tabRejected.IsVisible = false;
            }
            if(Department == "NDT" || Department == "IT")
            {
                if (tabRaised != null)
                    tabRaised.IsVisible = true;
                if (tabNewRaising != null)
                    tabNewRaising.IsVisible = false;
                if (tabAccepted != null)
                    tabAccepted.IsVisible = true;
                if (tabRejected != null)
                    tabRejected.IsVisible = true;
            }
        }

    }


}
