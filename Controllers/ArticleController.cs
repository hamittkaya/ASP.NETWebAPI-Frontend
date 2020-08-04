using System.Threading.Tasks;
using BlogFrontend.ApiServices.Abstract;
using BlogFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogFrontend.Controllers{
    public class ArticleController: Controller{
         private readonly IArticleApiService _blogApiService;
    
        public ArticleController(IArticleApiService blogApiService)
        {
            _blogApiService=blogApiService;
        }
        
        public async Task<IActionResult> Index(){
           // TempData["active"]="blog";
            return View(await _blogApiService.GetAllAsync());
        }

        public IActionResult Create(){
           // TempData["active"]="blog";
            return View(new ArticleAddModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ArticleAddModel model){
           // TempData["active"]="blog";
            if(ModelState.IsValid){
               await _blogApiService.AddAsync(model);
               return RedirectToAction("Index");
            }
            return View(model);
        }

         public async Task<IActionResult> Update(int id){
            var blogList= await _blogApiService.GetByIdAsync(id);

            return View(new ArticleUpdateModel{
                ArticleId=blogList.ArticleId,
                Title=blogList.Title,
                Description=blogList.Description,
                ShortDescription=blogList.ShortDescription
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateModel model){
            if(ModelState.IsValid){
                await _blogApiService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id){
            await _blogApiService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}