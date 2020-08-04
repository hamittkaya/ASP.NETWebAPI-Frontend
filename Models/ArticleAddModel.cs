
using Microsoft.AspNetCore.Http;

namespace BlogFrontend.Models{
    public class ArticleAddModel{
        public int UserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}