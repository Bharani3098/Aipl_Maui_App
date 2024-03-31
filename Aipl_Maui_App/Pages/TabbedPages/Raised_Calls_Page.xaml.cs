using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Aipl_Maui_App.TabbedPages;
using System.Windows.Input;
using Aipl_Maui_App.Services;
using CommunityToolkit.Maui.Views;
using Aipl_Maui_App.Pages;

namespace Aipl_Maui_App.Tabbed_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Raised_Calls_Page : ContentPage
    {
        readonly IJobGetraisedCallsRepository _raisedjobRepository = new RaisedCallServices();

        readonly IUpdateJobRepository _updateJobRepository = new UpdateJobservices();

        readonly IDeleteJobRepository deleteJobRepository = new DeleteJobServices();

        public List<RaisedCalls>? Raised_Calls { get; set; }

        public List<Grouping> raised_Calls { get; set; } = new List<Grouping>();

        public Raised_Calls_Page()
        {
            InitializeComponent();

            LoadRaisedCalls();
        }
        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand => new Command(ExecuteRefreshCommand);

        private void ExecuteRefreshCommand()
        {
            IsRefreshing = false;
        }

        private bool isOpen = false;

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                isOpen = true;

                await ((Frame)sender).ScaleTo(0.8, 30, Easing.BounceOut);
                await Task.Delay(30);
                await ((Frame)sender).ScaleTo(1, 30, Easing.BounceOut);

                FloatMenuItem1.IsVisible = true;
                await FloatMenuItem1.TranslateTo(0, 0, 30);
                await FloatMenuItem1.TranslateTo(0, -20, 30);
                await FloatMenuItem1.TranslateTo(0, 0, 50);
            }
            else
            {
                isOpen = false;

                await ((Frame)sender).ScaleTo(0.8, 30, Easing.BounceIn);
                await Task.Delay(30);
                await ((Frame)sender).ScaleTo(1, 30, Easing.BounceIn);

                await FloatMenuItem1.TranslateTo(0, 0, 30);
                await FloatMenuItem1.TranslateTo(0, -20, 30);
                await FloatMenuItem1.TranslateTo(0, 0, 50);
                FloatMenuItem1.IsVisible = false;
            }
        }

        private async void FloatMenuItem1Tap_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("New_Call_Page");

            isOpen = false;

            await FloatMenuItem1.TranslateTo(0, 0, 30);
            await FloatMenuItem1.TranslateTo(0, -20, 30);
            await FloatMenuItem1.TranslateTo(0, 0, 50);
            FloatMenuItem1.IsVisible = false;
        }

        private void LoadRaisedCalls()
        {
            var jbdt = _raisedjobRepository.GetRaisedCalls();

            raised_Calls = new List<Grouping>();

            if (jbdt != null)
            {
                Raised_Calls = jbdt.Result.ToList();
                
                List<RaisedCalls> RaisedCalls1 = new();
                for (int j = 0; j < Raised_Calls.Count; j++)
                {
                    if (Raised_Calls[j].NDT_Offering.ToString() == "RT")
                    {
                        RaisedCalls1.Add(Raised_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count > 0)
                    raised_Calls.Add(new Grouping("Radiography Test", RaisedCalls1));

                RaisedCalls1 = new();
                for (int j = 0; j < Raised_Calls.Count; j++)
                {
                    if (Raised_Calls[j].NDT_Offering.ToString() == "UT")
                    {
                        RaisedCalls1.Add(Raised_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count > 0)
                    raised_Calls.Add(new Grouping("Ultrasonic Test", RaisedCalls1));

                RaisedCalls1 = new();
                for (int j = 0; j < Raised_Calls.Count; j++)
                {
                    if (Raised_Calls[j].NDT_Offering.ToString() == "MT")
                    {
                        RaisedCalls1.Add(Raised_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count > 0)
                    raised_Calls.Add(new Grouping("Magnetic Pratical Test", RaisedCalls1));
            }

            RaisedJobCollectionView.ItemsSource = raised_Calls;
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            PullToRefresh.IsRefreshing = true;
            LoadRaisedCalls();
            PullToRefresh.IsRefreshing = false;
        }


        //private async Task<bool> jobDeleted(object sender, string Desc)
        //{
        //    var sel_jobNo = sender as SwipeItem;

        //    var Jbno = sel_jobNo.BindingContext as RaisedCalls;

        //    string Row_Id =Jbno.Id.ToString();

        //    Updatejob updttj = new Updatejob();

        //    updttj.Row_ID = Row_Id;
        //    updttj.Description = Desc;
        //    updttj.Checked_Date = GeneralFunc.RevDate(DateTime.Now.Date.ToString());
        //    updttj.Checked_By = Preferences.Get("UserId", " ");
        //    updttj.Del_tag = "Y";
        //    updttj.Status = "R";

        //    if (await deleteJobRepository.DeleteJob(updttj))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private async Task<bool> JobUpdated(object sender, string Desc, string Status, string Del_Tag)
        {
            var sel_jobNo = sender as SwipeItem;

            var Jbno = sel_jobNo.BindingContext as RaisedCalls;
            string Row_Id = Jbno.Id.ToString();
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
                    LoadRaisedCalls();
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
                    LoadRaisedCalls();
                    await Shell.Current.DisplayAlert("Success", "Job Updated Successfully", "Continue");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Unable to Accept \r\n Something Went Wrong", "Continue");
                }
            }
        }

        private async void JobCollectionTapped_Tapped(object sender, TappedEventArgs e)
        {
            var Sel_Job_No = RaisedJobCollectionView.SelectedItem as RaisedCalls;

            string Job_No = Sel_Job_No.Job_No.ToString();
            string Row_Id = Sel_Job_No.Id.ToString();

            //await Shell.Current.GoToAsync("Inspect_Calls", true);

            await Navigation.PushAsync(new Inspect_Calls(Row_Id), true);
        }
    }
}