using System.Collections.Generic;
using System.Threading.Tasks;
using BlogFrontend.Models;

namespace BlogFrontend.ApiServices.Abstract{
    public interface ICategoryApiService
    {
        Task<List<CategoryListModel>> GetAllAsync();
        Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsCount(); 
        Task<CategoryListModel> GetByIdAsync(int id);
    }
}