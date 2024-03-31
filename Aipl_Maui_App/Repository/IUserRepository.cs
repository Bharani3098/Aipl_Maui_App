using Aipl_Maui_App.Model;

namespace Aipl_Maui_App.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string User_Id, string PassWord);
    }
}
