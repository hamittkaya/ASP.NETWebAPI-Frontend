using BlogFrontend.ApiServices.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogFrontend.ViewComponents{
    public class CategoryListViewModel : ViewComponent{
        private readonly ICategoryApiService _categoryApiService;
        public CategoryListViewModel(ICategoryApiService categoryApiService)
        {
            _categoryApiService=categoryApiService;
        }
        public IViewComponentResult Invoke(){
            return View(_categoryApiService.GetAllWithBlogsCount().Result);
        }
    }
}