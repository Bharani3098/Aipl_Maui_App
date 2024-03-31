using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Newtonsoft.Json;
using System.Net;

namespace Aipl_Maui_App.Services
{
    public class JobServices : IJobRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api";

        public async Task<List<Jobs>> GetJobDetails()
        {
            try
            {
                string str_url = baseurl + "/Job/GetJob";

                //var jobs = new List<Jobs>();
                //var client = new HttpClient();

                //client.BaseAddress = new Uri(str_url);
                //HttpResponseMessage response = await client.GetAsync("");

                //if (response.IsSuccessStatusCode)
                //{
                //    string Content = response.Content.ReadAsStringAsync().Result;
                //    jobs = JsonConvert.DeserializeObject<List<Jobs>>(Content);

                //    if(jobs != null)
                //    {
                //        return jobs;
                //    }
                //    else
                //    {
                //        return jobs ?? new List<Jobs>();
                //    }
                //}
                //else
                //{
                //    return null!;
                //}
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<Jobs>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos;
                    }
                    else
                    {
                        return job_Nos ?? new List<Jobs>();
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

    public class RaisedCallServices : IJobGetraisedCallsRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api";

        public async Task<List<RaisedCalls>> GetRaisedCalls()
        {
            try
            {
                string str_url = baseurl + "/RT_Offering";

                //using (HttpClient client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(str_url);

                //    HttpResponseMessage response = await client.GetAsync("");

                //    if (response.IsSuccessStatusCode)
                //    {
                //        string responseData = await response.Content.ReadAsStringAsync();

                //        if (!string.IsNullOrEmpty(responseData))
                //        {
                //            return JsonConvert.DeserializeObject<List<RaisedCalls>>(responseData) ?? new List<RaisedCalls>();
                //        }
                //        else
                //        {
                //            return new List<RaisedCalls>();
                //        }
                //    }
                //    else
                //    {
                //        response.EnsureSuccessStatusCode();
                //        return null!;
                //    }
                //}

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<RaisedCalls>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos; //Needs To return List of Raised Calls
                    }
                    else
                    {
                        return job_Nos ?? new List<RaisedCalls>();
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

        public async Task<List<RaisedCallsDetails>> GetRaisedCalls(string ID)
        {
            try
            {
                string str_url = baseurl + "/RT_Offering"+"/"+ID;

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(str_url);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<RaisedCallsDetails>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos ?? new List<RaisedCallsDetails>(); //Needs To return List of Raised Calls
                    }
                    else
                    {
                        return new List<RaisedCallsDetails>();
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

    public class AcceptedCallsServices : IAcceptedCallsRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api";

        public async Task<List<RaisedCalls>> GetAcceptedCalls()
        {
            try
            {
                string str_url = baseurl + "/AcceptedCalls";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<RaisedCalls>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos; //Needs To return List of Raised Calls
                    }
                    else
                    {
                        return job_Nos ?? new List<RaisedCalls>();
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

    public class RejectedCallsServices : IRejectedCallsRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api";

        public async Task<List<RaisedCalls>> GetRejectedCalls()
        {
            try
            {
                string str_url = baseurl + "/RejectedCalls";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<RaisedCalls>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos; //Needs To return List of Raised Calls
                    }
                    else
                    {
                        return job_Nos ?? new List<RaisedCalls>();
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

    public class FormFillServices : IFillFormRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_App/api";

        public async Task<List<FillForm>> GetDdlFills()
        {
            try
            {
                string str_url = baseurl + "/Fill_Form";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                if (!string.IsNullOrEmpty(responsereader))
                {
                    var job_Nos = JsonConvert.DeserializeObject<List<FillForm>>(responsereader);

                    if (job_Nos != null)
                    {
                        return job_Nos; //Needs To return List of Raised Calls
                    }
                    else
                    {
                        return job_Nos ?? new List<FillForm>();
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
