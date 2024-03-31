using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Aipl_Maui_App.Services;

namespace Aipl_Maui_App.Pages;

public partial class LoginPage : ContentPage
{
    readonly IUserRepository loginRepository = new UserServices();

    public LoginPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsUserLoggedIn())
        {
            NavigateToMainPage();
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            string U_Id = txt_userName.Text;
            string U_pass = txt_passWord.Text;
            NavigateToMainPage();
            return;

            //if (string.IsNullOrWhiteSpace(U_Id) && string.IsNullOrWhiteSpace(U_pass))
            //{
            //    await Shell.Current.DisplayAlert("Error", "Invalid Credentials", "OK");
            //    return;
            //}
            //User user = await loginRepository.Login(U_Id, U_pass);
            //if (user != null)
            //{
            //    string message;
            //    if(user.Emp_Status == "Y")
            //    {
            //        message = "User Not Allowed";
            //        await Shell.Current.DisplayAlert("Error", message, "Ok");
            //        return;
            //    }
            //    else
            //    {
            //        string User_Status = user.Emp_Status.ToString();
            //        string User_Name = user.User_name.ToString();
            //        string Department = user.Department_Name.ToString();
            //        string Designation = user.Designation.ToString();
            //        string Pass = user.Password.ToString();
            //        string User_ID = user.User_id.ToString();

            //        if(User_ID != U_Id || Pass != U_pass)
            //        {
            //            await Shell.Current.DisplayAlert("Error", "Invalid User Credentials", "Try Again");
            //            return;
            //        }

            //        Preferences.Default.Set("UserId", User_ID);
            //        Preferences.Default.Set("Pass", Pass);
            //        Preferences.Default.Set("UserName", User_Name);
            //        Preferences.Default.Set("Department", Department);
            //        Preferences.Default.Set("Designation", Designation);

                   
            //        NavigateToMainPage();
            //        return;
            //    }
            //}
        }
        catch(Exception Ex)
        {

            NavigateToMainPage();

            //string Message = Ex.Message.ToString();

            //await Shell.Current.DisplayAlert("Error", Message, "Ok");

            //Preferences.Default.Clear();
        }       
    }

    private async void NavigateToMainPage()
    {
        MessagingCenter.Send(this, "UpdateUserLabels");
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");        
    }

    private static bool IsUserLoggedIn()
    {
        if(!string.IsNullOrEmpty(Preferences.Get("UserId", null)) && !string.IsNullOrEmpty(Preferences.Get("Pass", null)))
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

}