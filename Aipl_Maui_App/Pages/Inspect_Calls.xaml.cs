using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Aipl_Maui_App.Services;
using Aipl_Maui_App.ViewModel;

namespace Aipl_Maui_App.Pages;
public partial class Inspect_Calls : ContentPage
{
	readonly InspectViewModel _inspectviewmodel;

    readonly IUpdateJobRepository _updateJobRepository = new UpdateJobservices();
    private string? Tbl_Rid { get; set; }
    public Inspect_Calls(string ID)
	{
		InitializeComponent();

        _inspectviewmodel = new InspectViewModel(ID);

        _inspectviewmodel.GetInspectionDetails();
        this.BindingContext = _inspectviewmodel;

        FillForm();
    }

    protected void FillForm()
    {
        if (_inspectviewmodel.Ndt_offering == "Radiography Test" && _inspectviewmodel.Type == "Job")
        {
            if(_inspectviewmodel.Row_Id is not null)
            {
                Tbl_Rid = _inspectviewmodel.Row_Id.ToString();

                Frame_RT.IsVisible = true;
                Frame_UT.IsVisible = false;
                Frame_test_Plate.IsVisible = false;
                Frame_Job.IsVisible = false;
            }
        }
        else if (_inspectviewmodel.Ndt_offering == "Radiography Test" && _inspectviewmodel.Type == "Weld Test Plate")
        {
            if (_inspectviewmodel.Row_Id is not null)
            {
                Tbl_Rid = _inspectviewmodel.Row_Id.ToString();

                Frame_RT.IsVisible = false;
                Frame_UT.IsVisible = false;
                Frame_test_Plate.IsVisible = true;
                Frame_Job.IsVisible = false;
            }
                
        }
        else if (_inspectviewmodel.Ndt_offering == "Radiography Test" && _inspectviewmodel.Type == "Production Test Coupon")
        {
            if (_inspectviewmodel.Row_Id is not null)
            {
                Tbl_Rid = _inspectviewmodel.Row_Id.ToString();

                Frame_RT.IsVisible = false;
                Frame_UT.IsVisible = false;
                Frame_test_Plate.IsVisible = false;
                Frame_Job.IsVisible = true;
            }

                
        }
        else if (_inspectviewmodel.Ndt_offering == "Ultrasonic Test" || _inspectviewmodel.Ndt_offering == "Magnetic Pratical Test")
        {
            if (_inspectviewmodel.Row_Id is not null)
            {
                Tbl_Rid = _inspectviewmodel.Row_Id.ToString();

                Frame_RT.IsVisible = false;
                Frame_UT.IsVisible = true;
                Frame_test_Plate.IsVisible = false;
                Frame_Job.IsVisible = false;
            }   
        }
        else
        {
            Frame_RT.IsVisible = false;
            Frame_UT.IsVisible = false;
            Frame_test_Plate.IsVisible = false;
            Frame_Job.IsVisible = false;
        }
    }

    private void Btn_Check_Tapped(object sender, TappedEventArgs e)
    {
        Accept_Invoked(sender, e);
    }

    private void Btn_Reject_Tapped(object sender, TappedEventArgs e)
    {
        Delete_Invoked(sender, e);
    }

    private async Task<bool> JobUpdated(object sender, string Desc, string Status, string Del_Tag)
    {
        string Jbno = Lbl_Job_No.Text;

        if(Tbl_Rid is not null)
        {
            string Row_Id = Tbl_Rid;
            Updatejob updttj = new Updatejob();

            updttj.Row_ID = Row_Id;
            updttj.Description = Desc;
            updttj.Checked_Date = GeneralFunc.RevDate(DateTime.Now.Date.ToString());
            updttj.Checked_By = Preferences.Get("UserId", " ");
            updttj.Status = Status;
            updttj.Del_tag = Del_Tag;

            if (await _updateJobRepository.UpdateJob(updttj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private async void Delete_Invoked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Wait", "Remarks", "OK", "Cancel");

        if (result == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(result))
        {
            await DisplayAlert("Error", "Remarks is Empty", "Try Again");
            return;
        }
        else
        {
            if (await JobUpdated(sender, result, "R", "Y"))
            {
                await Shell.Current.GoToAsync("..");
                await Shell.Current.DisplayAlert("Success", "JobDeletedSuccessfully", "Continue");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Unable to Delete \r\n Something Went Wrong", "Continue");
            }
        }
    }

    private async void Accept_Invoked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Wait", "Remarks", "OK", "Cancel");

        if (result == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(result))
        {
            await DisplayAlert("Error", "Remarks is Empty", "Try Again");
            return;
        }
        else
        {
            if (await JobUpdated(sender, result, "C", "N"))
            {
                await Shell.Current.GoToAsync("..");
                await Shell.Current.DisplayAlert("Success", "Job Updated Successfully", "Continue");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Unable to Accept \r\n Something Went Wrong", "Continue");
            }
        }
    }
}