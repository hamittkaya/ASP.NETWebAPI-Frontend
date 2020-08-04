using System.Threading.Tasks;
using BlogFrontend.ApiServices.Abstract;
using BlogFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogFrontend.Controllers{
    public class AccountController : Controller{
        private readonly IAuthApiService _authApiService;
        public AccountController(IAuthApiService authApiService)
        {
            _authApiService=authApiService;
        }
        public IActionResult SignIn(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel userLoginModel){
             if(await _authApiService.SignIn(userLoginModel)){
                 return RedirectToAction("Index","Home",new{@area="Admin"});
             }

             return View();
        }
    }
}