using System.Collections.Generic;
using System.Threading.Tasks;
using BlogFrontend.Models;

namespace BlogFrontend.ApiServices.Abstract{
    public interface IArticleApiService
    {
        Task<List<ArticleListModel>> GetAllAsync();
        Task<ArticleListModel> GetByIdAsync(int id);
        Task<List<ArticleListModel>> GetAllByCategoryIdAsync(int id);
        Task AddAsync(ArticleAddModel model);
        Task UpdateAsync(ArticleUpdateModel model);
        Task DeleteAsync(int id);
    }
}