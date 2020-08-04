using System.Threading.Tasks;

namespace BlogFrontend.ApiServices.Abstract{
    public interface IImageApiService{
        Task<string> GetBlogImageByIdAsync(int id);
    }
}