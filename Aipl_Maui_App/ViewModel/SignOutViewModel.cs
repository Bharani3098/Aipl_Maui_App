using Aipl_Maui_App.Pages;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipl_Maui_App.ViewModel
{
    public partial class SignOutViewModel : BaseViewModel
    {
        [ICommand]
        async void SignOut()
        {
            Preferences.Default.Clear();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }        
    }
}
