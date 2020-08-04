using Microsoft.AspNetCore.Http;

namespace BlogFrontend.Models{
    public class ArticleUpdateModel{
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}