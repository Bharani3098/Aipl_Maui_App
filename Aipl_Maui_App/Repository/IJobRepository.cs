using Aipl_Maui_App.Model;

namespace Aipl_Maui_App.Repository
{

    //this whole repos is used to retrieve all the information on raised calls 
    //web api is in JobServices

    public interface IJobRepository
    {
        Task<List<Jobs>> GetJobDetails();
    }

    public interface IJobGetraisedCallsRepository
    {
        Task<List<RaisedCalls>> GetRaisedCalls();

        Task<List<RaisedCallsDetails>> GetRaisedCalls(string ID);
    }

    public interface IAcceptedCallsRepository
    {
        Task<List<RaisedCalls>> GetAcceptedCalls();
    }

    public interface IRejectedCallsRepository
    {
        Task<List<RaisedCalls>> GetRejectedCalls();
    }

    public interface IFillFormRepository
    {
        Task<List<FillForm>> GetDdlFills();
    }
 }
