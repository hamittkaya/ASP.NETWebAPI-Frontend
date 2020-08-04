using System.Threading.Tasks;
using BlogFrontend.ApiServices.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogFrontend.Controllers{
    public class HomeController: Controller{
        private readonly IArticleApiService _articleApiService;
        public HomeController(IArticleApiService articleApiService)
        {
            _articleApiService = articleApiService;
        }
        public async Task<IActionResult> Index(int? categoryId)
        {
            if(categoryId.HasValue){
                ViewBag.ActiveCategory=categoryId;
                return View(await _articleApiService.GetAllByCategoryIdAsync((int)categoryId));      

            }
            return View( await _articleApiService.GetAllAsync());
        }

         public async Task<IActionResult> BlogDetail(int id){
            return View(await _articleApiService.GetByIdAsync(id));
        }
    }
}