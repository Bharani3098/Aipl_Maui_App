using Aipl_Maui_App.Model;

namespace Aipl_Maui_App.Repository
{
    public interface ITrailJobRepository
    {
        Task<List<TrailJobNo>> GetTrailJobDetails(string Job_No);
    }
}
