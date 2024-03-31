using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aipl_Maui_App.ViewModel
{    
    public partial class LogInPageViewModel : BaseViewModel
    {
        #region Commands
        [ICommand]
        async void Login()
        {   
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        #endregion
    }
}
