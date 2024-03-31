using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aipl_Maui_App.Services
{

    //Calling The web api for all The Insert operation
    public class InsertJobServices : IInsertJobRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api/RT_Offering/Post";
        public async Task<bool> InsertOrUpdate(NDTONJOBS JsonDetails)
        {
            string JsonData = JsonConvert.SerializeObject(JsonDetails);

            string str_url = baseurl;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(str_url, content);

                string successcode = response.IsSuccessStatusCode.ToString();

                if (response.IsSuccessStatusCode) return true;
                else return false;
            }
            catch (Exception Ex)
            {
                string Msg = Ex.Message.ToString();
                await Shell.Current.DisplayAlert(Msg, "Unable to Connect to AIPL server ", "try again");
                return false;
            }
        }

    }

    public class UpdateJobservices : IUpdateJobRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api/RT_Offering";

        public async Task<bool> UpdateJob(Updatejob updt)
        {
            string JsonData = JsonConvert.SerializeObject(updt);

            if(updt.Row_ID is null)
            {
                return false;
            }

            string str_url = baseurl + "/" + updt.Row_ID.ToString();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PutAsync(str_url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch (Exception Ex)
                {
                    string Msg = Ex.Message.ToString();
                    await Shell.Current.DisplayAlert(Msg, "Unable to Connect to AIPL server ", "try again");
                    return false;
                }
            }
        }
    }

    public class DeleteJobServices : IDeleteJobRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api/RT_Offering";

        public async Task<bool> DeleteJob(Updatejob delt)
        {
            string JsonData = JsonConvert.SerializeObject(delt);

            if(delt.Row_ID is null)
            {
                return false;
            }

            string str_url = baseurl + "/" + delt.Row_ID.ToString();

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(str_url);

                if (response.IsSuccessStatusCode) return true;
                else return false;
            }
            catch (Exception Ex)
            {
                string Msg = Ex.Message.ToString();
                await Shell.Current.DisplayAlert(Msg, "Unable to Connect to AIPL server ", "try again");
                return false;
            }
        }
    }
}
