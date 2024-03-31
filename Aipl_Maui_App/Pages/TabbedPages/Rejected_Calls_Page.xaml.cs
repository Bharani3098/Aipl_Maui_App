using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Aipl_Maui_App.Services;

namespace Aipl_Maui_App.Tabbed_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rejected_Calls_Page : ContentPage
    {
        readonly IRejectedCallsRepository _RejectedCallsRepository = new RejectedCallsServices();

        private List<RaisedCalls>? Rejected_Calls { get; set; }

        public List<Grouping> rejected_Calls { get; set; } = new List<Grouping>();

        public Rejected_Calls_Page()
        {
            InitializeComponent(); 

            LoadAcceptedCalls();
        }

        private void LoadAcceptedCalls()
        {
            var jbdt = _RejectedCallsRepository.GetRejectedCalls();

            if (jbdt != null)
            {
                Rejected_Calls = jbdt.Result;

                rejected_Calls = new List<Grouping>();

                List<RaisedCalls> RaisedCalls1 = new();
                for (int j = 0; j < Rejected_Calls.Count; j++)
                {
                    if (Rejected_Calls[j].NDT_Offering.ToString() == "RT")
                    {
                        RaisedCalls1.Add(Rejected_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count > 0)
                    rejected_Calls.Add(new Grouping("Radiography Test", RaisedCalls1));

                RaisedCalls1 = new();
                for (int j = 0; j < Rejected_Calls.Count; j++)
                {
                    if (Rejected_Calls[j].NDT_Offering.ToString() == "UT")
                    {
                        RaisedCalls1.Add(Rejected_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count > 0)
                    rejected_Calls.Add(new Grouping("Ultrasonic Test", RaisedCalls1));

                RaisedCalls1 = new();
                for (int j = 0; j < Rejected_Calls.Count; j++)
                {
                    if (Rejected_Calls[j].NDT_Offering.ToString() == "MT")
                    {
                        RaisedCalls1.Add(Rejected_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count > 0)
                    rejected_Calls.Add(new Grouping("Magnetic Pratical Test", RaisedCalls1));
            }

            if(rejected_Calls.Count>0)
                RejectedJobCollectionView.ItemsSource = rejected_Calls;
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            PullToRefresh.IsRefreshing = true;
            LoadAcceptedCalls();
            PullToRefresh.IsRefreshing = false;
        }
    }
}