using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipl_Maui_App.Model
{
    public class NDTONJOBS
    {
        public string? Inspection_Id { get; set; }//nvarchar
        public string? Job_No { get; set; }//nvarchar
        public string? DJob_No { get; set; }//nvarchar
        public string? Raised_Date { get; set; }//date
        public string? NDT_Offering { get; set; }//nvarchar
        public string? Type { get; set; }//nvarchar
        public int No_Of_Joint { get; set; }//int
        public string? Joints_Reference { get; set; }//nvarchar
        public string? Test_Condition { get; set; }//nvarchar
        public string? Drawing_Reference_No { get; set; }//nvarchar
        public string? Extent_Of_Testing { get; set; }//nvarchar
        public string? Weld_Process { get; set; }//nvarchar
        public string? Dimension { get; set; }//nvarchar
        public string? Reinforcement { get; set; }//nvarchar
        public string? Welder_Id { get; set; }//nvarchar
        public string? Location { get; set; }//nvarchar
        public string? Raised_by { get; set; }//nvarchar
        public string? Weld_Position { get; set; }//nvarchar
        public string? Material { get; set; }//nvarchar
        public string? Mat_Thickness { get; set; }//nvarchar
    }

    public class Updatejob
    {
        public string? Row_ID { get; set; }
        public string? Description { get; set; }
        public string? Checked_Date { get; set; }
        public string? Checked_By { get; set; }
        public string? Status { get; set; }
        public string? Del_tag { get; set; }

    }
}
