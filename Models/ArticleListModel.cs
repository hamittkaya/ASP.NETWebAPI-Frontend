using System;

namespace BlogFrontend.Models{
    public class ArticleListModel{
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
    }
}