
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aipl_Maui_App.ViewModel
{
    public partial class BaseViewModel:ObservableObject
    {
        [ObservableProperty]
        public bool _isbusy;

        [ObservableProperty]
        private string? _title;

        [ObservableProperty]
        public string? _inspection_Id;

        [ObservableProperty]
        public string? _welder_Id;

        [ObservableProperty]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime _raised_Date;

        [ObservableProperty]
        public string? _ndt_offering;

        [ObservableProperty]
        public string? _type;

        [ObservableProperty]
        public int _noofjoints;

        [ObservableProperty]
        public string? _joint_Reference;

        [ObservableProperty]
        public string? _test_Condition;

        [ObservableProperty]
        public string? _drawing_Reference_No;

        [ObservableProperty]
        public string? _extent_Of_Testing;

        [ObservableProperty]
        public string? _weld_Process;

        [ObservableProperty]
        public string? _dimension;

        [ObservableProperty]
        public string? _reinforcement;

        [ObservableProperty]
        public string? _location;

        [ObservableProperty]
        public string? _raised_by;

        [ObservableProperty]
        public string? _weld_position;

        [ObservableProperty]
        public string? _material;

        [ObservableProperty]
        public string? _mat_thickness;

        [ObservableProperty]
        public string? _raised_name;

        [ObservableProperty]
        public string? _checked_name;

        [ObservableProperty]
        public string? _Approved_name;

        [ObservableProperty]
        public string? _job_No;

        [ObservableProperty]
        public string? _tag_No;

        [ObservableProperty]
        public string? _row_Id;

        [ObservableProperty]
        public string? _welder_Type;

    }
}
