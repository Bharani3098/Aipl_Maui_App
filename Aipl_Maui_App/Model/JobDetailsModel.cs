namespace Aipl_Maui_App.Model
{
    public class Jobs
    {
        public string? Job_No { get; set; }

        public string? Djob_No { get; set; }
    }

    public class RaisedCalls
    {
        public string? Job_No { get; set; }

        public string? Description { get; set; }

        public string? Id { get; set; }

        public string? NDT_Offering {  get; set; }
    }

    public class FillForm
    {
        public List<string>? Test_Condition_Name { get; set; }
        public List<string>? Test_Types { get; set; }
        public List<string>? Ins_Type { get; set; }
        public List<string>? Extn_test { get; set; }
        public List<string>? Weld_Process { get; set; }
        public List<string>? Welder_Id { get; set; }        
        public List<string>? Weld_Position { get; set; }
        public List<string>? Welder_Type { get; set; }
        public List<string>? Weld_Material { get; set; }
        public List<string>? Job_No { get; set; }
    }

    public class RaisedCallsDetails
    {
        public int Id { get; set; }
        public string? Inspection_Id { get; set; }
        public string? Job_No { get; set; }
        public string? Tag_No { get; set; }
        public string? Raised_Date { get; set; }
        public string? NDT_Offering { get; set; }
        public string? Type { get; set; }
        public int No_Of_Joint { get; set; }
        public string? Joints_Reference { get; set; }
        public string? Test_Condition { get; set; }
        public string? Drawing_Reference_No { get; set; }
        public string? Extent_Of_Testing { get; set; }
        public string? Weld_Process { get; set; }
        public string? Dimension { get; set; }
        public string? Reinforcement { get; set; }
        public string? Welder_Id { get; set; }
        public string? Location { get; set; }
        public string? Raised_by { get; set; }
        public string? Weld_Position { get; set; }
        public string? Material { get; set; }
        public string? Mat_Thickness { get; set; }
        public string? Raised_Name { get; set; }
        public string? Checked_Name { get; set; }
        public string? Approved_Name { get; set; }
        public string? Welder_Type { get; set; }

    }

    public class Grouping(string groupTitle, List<RaisedCalls> raisedCalls) : List<RaisedCalls>(raisedCalls)
    {
        public string GroupTitle { get; set; } = groupTitle;
    }
}
