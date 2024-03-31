using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace Aipl_Maui_App.Services
{
    public class TrailJobServices : ITrailJobRepository
    {
        public async Task<List<TrailJobNo>> GetTrailJobDetails(string Job_no)
        {
            try
            {
                string str_url = "http://192.168.0.17/webapi_App/api/Job/GetSpecificJob/" + Job_no;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<TrailJobNo>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos;
                    }
                    else
                    {
                        return job_Nos ?? new List<TrailJobNo>(); //if the Job_nos variable is empty return a empty list so that the application wont throw an exception and goes into break mode
                    }
                }
                else
                {
                    return null!;
                }

            }
            catch (Exception Ex)
            {
                string Message = Ex.Message.ToString();
                await Shell.Current.DisplayAlert("Connection error", "Unable connect to the database", "try again");
                return null!;
            }
        }
    }
}
