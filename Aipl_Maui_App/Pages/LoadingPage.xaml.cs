using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using System.Data;
using System.Linq;

namespace Aipl_Maui_App.Pages;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
    }

    private void Btn_Accepted_Calls_Clicked(object sender, EventArgs e)
    {
        BxView_Acceptedcalls.IsVisible = true;
        BxView_Raisedcalls.IsVisible = false;
        BxView_Rejectedcalls.IsVisible = false;
        JobListCollectionView.IsVisible = false;
    }

    private void Btn_Raised_Calls_Clicked(object sender, EventArgs e)
    {
        BxView_Acceptedcalls.IsVisible = false;
        BxView_Raisedcalls.IsVisible = true;
        BxView_Rejectedcalls.IsVisible = false;
        JobListCollectionView.IsVisible = true;
    }

    private void Btn_Rejected_Calls_Clicked(object sender, EventArgs e)
    {
        BxView_Acceptedcalls.IsVisible = false;
        BxView_Raisedcalls.IsVisible = false;
        BxView_Rejectedcalls.IsVisible = true;

        JobListCollectionView.IsVisible = false;
    }

}