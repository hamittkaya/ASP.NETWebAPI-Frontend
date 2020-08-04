using BlogFrontend.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BlogFrontend.Areas.Admin.Controllers{
    [Area("Admin")]
    public class HomeController:Controller{
        [JwtAuthorize]
        public IActionResult Index(){
            return View();
        }
    }
}