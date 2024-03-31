using Aipl_Maui_App.Model;
using Aipl_Maui_App.Repository;
using Newtonsoft.Json;
using System.Net;

namespace Aipl_Maui_App.Services
{
    public class UserServices : IUserRepository
    {
        private readonly string baseurl = "http://192.168.0.17/webapi_app/api/";

        public async Task<User> Login(string UserId, string PWd)
        {
            try
            {
                string str_url = baseurl + "/Values/" + UserId;

                var userinfo = new List<User>();

                var client = new HttpClient();

                client.BaseAddress = new Uri(str_url);
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string Content = response.Content.ReadAsStringAsync().Result;

                    if (Content != null)
                    {
                        userinfo = JsonConvert.DeserializeObject<List<User>>(Content);
                        if(userinfo != null) 
                        {
                            if(userinfo.FirstOrDefault() is not null)
                            {
                                string User_Status = Convert.ToString(userinfo.FirstOrDefault().Emp_Status);
                                string User_Name = userinfo.FirstOrDefault().User_name.ToString();
                                string Department = userinfo.FirstOrDefault().Department_Name.ToString();
                                string Designation = userinfo.FirstOrDefault().Designation.ToString();
                                string Pass = userinfo.FirstOrDefault().Password.ToString();
                                string User_ID = userinfo.FirstOrDefault().User_id.ToString();

                                if (User_Status == "Y")
                                {
                                    await Shell.Current.DisplayAlert("Error", "User does not exist", "Try again");
                                    return null!;
                                }

                                if (User_ID != UserId || Pass != PWd)
                                {
                                    await Shell.Current.DisplayAlert("Error", "Invalid User Credentials", "Try Again");
                                    return null!;
                                }

                                Preferences.Default.Set("UserId", User_ID);
                                Preferences.Default.Set("Pass", Pass);
                                Preferences.Default.Set("UserName", User_Name);
                                Preferences.Default.Set("Department", Department);
                                Preferences.Default.Set("Designation", Designation);

                                return await Task.FromResult(userinfo.FirstOrDefault());
                            }
                            else
                            {
                                return null!;
                            }
                        }
                        else
                        {
                            return null!;
                        }
                    }
                    else
                    {
                        return null!;
                    }
                }
                else
                {
                    return null!;
                }

                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str_url);
                //WebResponse response = request.GetResponse();
                //Stream dataStream = response.GetResponseStream();
                //StreamReader sreader = new StreamReader(dataStream);
                //string responsereader = sreader.ReadToEnd();
                //response.Close();

                //if(!string.IsNullOrEmpty(responsereader))
                //{
                //    List<User> user = JsonConvert.DeserializeObject<List<User>>(responsereader);

                //    //var objResponse1 = JsonConvert.DeserializeObject<List<User>>(responsereader);

                //    if (user != null)
                //    {
                //        return user[0];
                //    }
                //}

                //return null!;
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message.ToString();
                await Shell.Current.DisplayAlert("Connection error", "Unable to Connect to AIPL server ", "try again");
                return null!;
            }
        }
    }
}
