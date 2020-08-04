using System.Threading.Tasks;
using BlogFrontend.Models;

namespace BlogFrontend.ApiServices.Abstract{
    public interface IAuthApiService{
        Task<bool> SignIn(UserLoginModel model);
    }
}