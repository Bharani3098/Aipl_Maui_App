using Aipl_Maui_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipl_Maui_App.Repository
{

    //This Whole Repos is used for Insert and Update of the NDT Details to the Database
    //web api's are called from insertjobservices
    public interface IInsertJobRepository
    {
        Task<bool> InsertOrUpdate(NDTONJOBS jsonDetails);
    }

    public interface IUpdateJobRepository 
    {
        Task<bool> UpdateJob(Updatejob updt);   
    }

    public interface IDeleteJobRepository
    {
        Task<bool> DeleteJob(Updatejob delt);
    }

}
