using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Aipl_Maui_App.Services;
using Microsoft.Toolkit.Mvvm.Input;

namespace Aipl_Maui_App.ViewModel
{
    public partial class InspectViewModel(string ID):BaseViewModel
    {
        readonly IJobGetraisedCallsRepository _raisedjobRepository = new RaisedCallServices();

        public List<RaisedCallsDetails>? Raised_Calls { get; set; }

        public void GetInspectionDetails()
        {
            var jbdt = _raisedjobRepository.GetRaisedCalls(ID);

            if(jbdt == null)
                return;

            Raised_Calls = jbdt.Result;

            if (Raised_Calls != null)
            {
                Title = Convert.ToString(Raised_Calls[0].Job_No);

                Inspection_Id = Convert.ToString(Raised_Calls[0].Inspection_Id);

                Welder_Id = Convert.ToString(Raised_Calls[0].Welder_Id);

                Raised_Date = Convert.ToDateTime(Raised_Calls[0].Raised_Date);

                Ndt_offering =Convert.ToString( Raised_Calls[0].NDT_Offering);

                Type =Convert.ToString(Raised_Calls[0].Type);

                Noofjoints = Convert.ToInt32(Raised_Calls[0].No_Of_Joint.ToString());

                Joint_Reference = Convert.ToString(Raised_Calls[0].Joints_Reference);

                Test_Condition = Convert.ToString(Raised_Calls[0].Test_Condition);

                Drawing_Reference_No = Convert.ToString(Raised_Calls[0].Drawing_Reference_No);

                Extent_Of_Testing = Convert.ToString(Raised_Calls[0].Extent_Of_Testing);

                Weld_Process = Convert.ToString(Raised_Calls[0].Weld_Process);

                Dimension = Convert.ToString(Raised_Calls[0].Dimension);

                Reinforcement = Convert.ToString(Raised_Calls[0].Reinforcement);

                Location = Convert.ToString(Raised_Calls[0].Location);

                Raised_by = Convert.ToString(Raised_Calls[0].Raised_by);

                Weld_position = Convert.ToString(Raised_Calls[0].Weld_Position);

                Material = Convert.ToString(Raised_Calls[0].Material);

                Mat_thickness = Convert.ToString(Raised_Calls[0].Mat_Thickness);

                Raised_name = Convert.ToString(Raised_Calls[0].Raised_Name);

                Job_No = Convert.ToString(Raised_Calls[0].Job_No);

                Tag_No = Convert.ToString(Raised_Calls[0].Tag_No);

                Row_Id = Convert.ToString(Raised_Calls[0].Id);

                Welder_Type = Convert.ToString(Raised_Calls[0].Welder_Type);

                //Checked_name = Raised_Calls[0].Checked_Name.ToString();

                //Approved_name = Raised_Calls[0].Approved_Name.ToString();
            }
        }
    }
}
