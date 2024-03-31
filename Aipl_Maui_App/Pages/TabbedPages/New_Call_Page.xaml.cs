using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using System.Collections.ObjectModel;
using Aipl_Maui_App.Services;
using System.Text;

namespace Aipl_Maui_App.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class New_Call_Page : ContentPage
    {
        private readonly ITrailJobRepository _trailjob = new TrailJobServices();

        private readonly IInsertJobRepository _insertJobRepository = new InsertJobServices();

        private readonly IFillFormRepository _FillddlRepository = new FormFillServices();        
        
        public New_Call_Page()
        {
            InitializeComponent();

            FillPickers();
        }

        private void FillPickers()
        {
            var jbdt = _FillddlRepository.GetDdlFills();

            if (jbdt != null)
            {
                List<FillForm> Fills = jbdt.Result as List<FillForm>;

                var firstFill = Fills.FirstOrDefault();
                if (firstFill != null)
                {
                    Pkr_Ins_Type.ItemsSource = firstFill.Ins_Type;
                    Pkr_Extn_Test.ItemsSource = firstFill.Extn_test;
                    picker_NDT.ItemsSource = firstFill.Test_Types;
                    Pkr_Test_Condtn.ItemsSource = firstFill.Test_Condition_Name;
                    Pkr_Weld_Process.ItemsSource = firstFill.Weld_Process;
                    Pkr_Weld_Process_1.ItemsSource = firstFill.Weld_Process;
                    Pkr_Welder_Id.ItemsSource = firstFill.Welder_Id;
                    Pkr_Welder_Id_1.ItemsSource = firstFill.Welder_Id;
                    Pkr_Weld_Position.ItemsSource = firstFill.Weld_Position;
                    Pkr_Material.ItemsSource = firstFill.Weld_Material;
                    Pkr_Welder_Type.ItemsSource = firstFill.Welder_Type;
                    Pkr_Job_No.ItemsSource = firstFill.Job_No;
                    Pkr_Job_No_1.ItemsSource = firstFill.Job_No;
                }

                picker_NDT_SelectedIndexChanged(new object(), new EventArgs());
            }
            else
            {
                DisplayAlert("Error", "Something Went Wrong", "Ok");
            }
        }

        public void GetJobDetails(string Job_NO)
        {
            Pkr_Drawing_Ref.Items.Clear();

            var jbdt = _trailjob.GetTrailJobDetails(Job_NO).Result.ToList();

            for(int i = 0; i < jbdt.Count; i++)
            {
                if(jbdt[i].Doc_No.ToString() != "")
                    Pkr_Drawing_Ref.Items.Add(jbdt[i].Doc_No.ToString());
            }
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            PullToRefresh.IsRefreshing = true;            
            PullToRefresh.IsRefreshing = false;
        }

        private async void Btn_Save_Clicked(object sender, EventArgs e)
        {
            if (await SaveNDTOffering())
            {
                await Shell.Current.GoToAsync("..");
                await Shell.Current.DisplayAlert("Success", " Inspection Call raised Successfully", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Unable Save Data", "OK");
            }
        }

        public async Task<bool> SaveNDTOffering()
        {
            NDTONJOBS inst = new NDTONJOBS();

            //When NDT is offered for Job with RT
            if (picker_NDT.SelectedIndex==0 && Pkr_Ins_Type.SelectedIndex == 0)
            {
                inst.Inspection_Id = "-"; 
                inst.Job_No = Pkr_Job_No.SelectedItem.ToString();
                inst.DJob_No = Txt_Tag_No.Text;
                inst.Raised_Date = GeneralFunc.RevDate(DateTime.Now.Date.ToString());
                if(picker_NDT.SelectedIndex == 0)
                {
                    inst.NDT_Offering = "RT";
                }
                if (picker_NDT.SelectedIndex == 1)
                {
                    inst.NDT_Offering = "UT";
                }
                if (picker_NDT.SelectedIndex == 2)
                {
                    inst.NDT_Offering = "MT";
                }

                inst.Type = Pkr_Ins_Type.SelectedItem.ToString();
                inst.No_Of_Joint = Convert.ToInt32(Txt_joints.Text);
                inst.Joints_Reference = Txt_Joint_Ref.Text;
                inst.Test_Condition = Pkr_Test_Condtn.SelectedItem.ToString();
                inst.Drawing_Reference_No = Pkr_Drawing_Ref.SelectedItem.ToString();
                inst.Extent_Of_Testing = Pkr_Extn_Test.SelectedItem.ToString();
                inst.Weld_Process = Pkr_Weld_Process.SelectedItem.ToString();
                inst.Dimension = Txt_Dmsn.Text;
                inst.Reinforcement = Txt_Reinforcement.Text;
                inst.Welder_Id = Pkr_Welder_Id.SelectedItem.ToString();
                inst.Location = Txt_Location.Text;
                inst.Raised_by = Preferences.Get("UserId", " ");
                inst.Weld_Position = "-";
                inst.Material = "-";
                inst.Mat_Thickness ="-";
            }
            //When NDT is Offered for Test_plate With RT
            else if(picker_NDT.SelectedIndex == 0 && Pkr_Ins_Type.SelectedIndex == 1)
            {
                inst.Inspection_Id = "-";
                inst.Job_No = "-";
                inst.DJob_No = "-";
                inst.Raised_Date = GeneralFunc.RevDate(DateTime.Now.Date.ToString());
                inst.NDT_Offering = picker_NDT.SelectedItem.ToString();
                inst.Type = Pkr_Ins_Type.SelectedItem.ToString();
                inst.No_Of_Joint = 0;
                inst.Joints_Reference = "-";
                inst.Test_Condition = "-";
                inst.Drawing_Reference_No = "-";
                inst.Extent_Of_Testing = "-";
                inst.Weld_Process = Pkr_Weld_Process_1.SelectedItem.ToString();
                inst.Dimension = "-";
                inst.Reinforcement = "-";
                inst.Welder_Id = Txt_Welder_Name.Text;
                inst.Location = "-";
                inst.Raised_by = Preferences.Get("UserId", " ");
                inst.Weld_Position = Pkr_Weld_Position.SelectedItem.ToString();
                inst.Material = Pkr_Material.SelectedItem.ToString();
                inst.Mat_Thickness = Txt_Mat_Thickness.Text;
            }
            //When NDT is Offered for Test_Coupon With RT
            else if(picker_NDT.SelectedIndex == 0 && Pkr_Ins_Type.SelectedIndex == 2)
            {
                inst.Inspection_Id = "-";
                inst.Job_No = Pkr_Job_No_1.SelectedItem.ToString();
                inst.DJob_No = "-";
                inst.Raised_Date = GeneralFunc.RevDate(DateTime.Now.Date.ToString());
                inst.NDT_Offering = picker_NDT.SelectedItem.ToString();
                inst.Type = Pkr_Ins_Type.SelectedItem.ToString();
                inst.No_Of_Joint = 0;
                inst.Joints_Reference = "-";
                inst.Test_Condition = "-";
                inst.Drawing_Reference_No = "-";
                inst.Extent_Of_Testing = "-";
                inst.Weld_Process = Pkr_Weld_Process_1.SelectedItem.ToString();
                inst.Dimension = "-";
                inst.Reinforcement = "-";
                inst.Welder_Id = Pkr_Welder_Id.SelectedItem.ToString();
                inst.Location = "-";
                inst.Raised_by = Preferences.Get("UserId", " ");
                inst.Weld_Position = Pkr_Weld_Position.SelectedItem.ToString();
                inst.Material = Pkr_Material.SelectedItem.ToString();
                inst.Mat_Thickness = Txt_Mat_Thickness.Text;
            }
            //When NDT is Offered for UT & MT
            else if(picker_NDT.SelectedIndex == 1 || picker_NDT.SelectedIndex == 2)
            {
                inst.Inspection_Id = "-";
                inst.Job_No = Pkr_Job_No.SelectedItem.ToString();
                inst.DJob_No = Txt_Tag_No.Text;
                inst.Raised_Date = GeneralFunc.RevDate(DateTime.Now.Date.ToString());
                inst.NDT_Offering = picker_NDT.SelectedItem.ToString();
                inst.Type = "-";
                inst.No_Of_Joint = Convert.ToInt32(Txt_joints.Text);
                inst.Joints_Reference = Txt_Joint_Ref.Text;
                inst.Test_Condition = Pkr_Test_Condtn.SelectedItem.ToString();
                inst.Drawing_Reference_No = Pkr_Drawing_Ref.SelectedItem.ToString();
                inst.Extent_Of_Testing = "-";
                inst.Weld_Process = "-";
                inst.Dimension = "-";
                inst.Reinforcement = "-";
                inst.Welder_Id = "-";
                inst.Location = "-";
                inst.Raised_by = Preferences.Get("UserId", " ");
                inst.Weld_Position = "-";
                inst.Material = "-";
                inst.Mat_Thickness = "-";
            }

            if (await _insertJobRepository.InsertOrUpdate(inst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void picker_NDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            frame_RT.IsVisible = false;
            frame_NotRT.IsVisible = false;

            Pkr_Ins_Type.SelectedIndex = -1;
            Pkr_Ins_Type.IsEnabled = false;

            if (picker_NDT.SelectedIndex == 0)
            {
                Pkr_Ins_Type.IsEnabled = true;
                frame_RT.IsVisible = false;

                Pkr_Extn_Test.IsEnabled = true;
                Pkr_Weld_Process.IsEnabled = true;
                Txt_Dmsn.IsEnabled = true;
                Txt_Reinforcement.IsEnabled = true;
                Txt_Location.IsEnabled = true;
                Pkr_Welder_Id.IsEnabled = true;
            }
            if(picker_NDT.SelectedIndex == 1 || picker_NDT.SelectedIndex == 2)
            {
                Pkr_Ins_Type.IsEnabled = false;
                frame_RT.IsVisible = true;

                Pkr_Extn_Test.IsEnabled = false;
                Pkr_Weld_Process.IsEnabled = false;
                Txt_Dmsn.IsEnabled = false;
                Txt_Reinforcement.IsEnabled = false;
                Txt_Location.IsEnabled = false;
                Pkr_Welder_Id.IsEnabled = false;
            }
        }

        private void Pkr_Ins_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            frame_RT.IsVisible = true;
            frame_NotRT.IsVisible = false;

            if (Pkr_Ins_Type.SelectedIndex == 1 || Pkr_Ins_Type.SelectedIndex==2)
            {
                if(Pkr_Ins_Type.SelectedIndex == 1)
                {
                    Pkr_Job_No_1.IsEnabled = false;
                    Pkr_Welder_Id_1.IsVisible = false;
                    Txt_Welder_Name.IsVisible = true;
                    Pkr_Welder_Type.IsEnabled = true;                    
                }
                else
                {
                    Pkr_Job_No_1.IsEnabled = true;
                    Pkr_Welder_Id_1.IsVisible = true;
                    Txt_Welder_Name.IsVisible = false;
                    Pkr_Welder_Type.IsEnabled = false;
                }

                frame_RT.IsVisible = false;
                frame_NotRT.IsVisible = true;
            }
        }

        private void Pkr_Job_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? Job_No = Pkr_Job_No.SelectedItem.ToString();

            GetJobDetails(Job_No);
        }
    }
}