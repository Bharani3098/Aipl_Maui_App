using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Aipl_Maui_App.Services;

namespace Aipl_Maui_App.Tabbed_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accepted_Calls_Page : ContentPage
    {
        readonly IAcceptedCallsRepository _acceptedCallsRepository = new AcceptedCallsServices();

        private List<RaisedCalls>? Accepted_Calls { get; set; }

        public List<Grouping> accepted_Calls { get; set; } = new List<Grouping>();

        public Accepted_Calls_Page()
        {
            InitializeComponent();

            LoadAcceptedCalls();
        }

        private void LoadAcceptedCalls()
        {
            var jbdt = _acceptedCallsRepository.GetAcceptedCalls();

            accepted_Calls = new List<Grouping>();

            if (jbdt != null)
            {
                Accepted_Calls = jbdt.Result.ToList();

                List<RaisedCalls> RaisedCalls1 = new();
                for (int j = 0; j < Accepted_Calls.Count; j++)
                {
                    string NDT_Offering_Type = Accepted_Calls[j].NDT_Offering.ToString();

                    if (NDT_Offering_Type == "RT")
                    {
                        RaisedCalls1.Add(Accepted_Calls[j]);
                    }
                }
                if (RaisedCalls1.Count>0)
                    accepted_Calls.Add(new Grouping("Radiography Test", RaisedCalls1));

                RaisedCalls1 = new();
                for (int j = 0; j < Accepted_Calls.Count; j++)
                {
                    if (Accepted_Calls[j].NDT_Offering.ToString() == "UT")
                    {
                        RaisedCalls1.Add(Accepted_Calls[j]);
                    }                    
                }
                if (RaisedCalls1.Count>0)
                    accepted_Calls.Add(new Grouping("Ultrasonic Test", RaisedCalls1));

                RaisedCalls1 = new();
                for (int j = 0; j < Accepted_Calls.Count; j++)
                {
                    if (Accepted_Calls[j].NDT_Offering.ToString() == "MT")
                    {
                        RaisedCalls1.Add(Accepted_Calls[j]);
                    }                    
                }
                if (RaisedCalls1.Count>0)
                    accepted_Calls.Add(new Grouping("Magnetic Pratical Test", RaisedCalls1));
            }

            AcceptedJobCollectionView.ItemsSource = accepted_Calls;
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            PullToRefresh.IsRefreshing = true;
            LoadAcceptedCalls();
            PullToRefresh.IsRefreshing = false;
        }
    }
}