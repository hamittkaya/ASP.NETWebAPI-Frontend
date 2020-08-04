using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlogFrontend.ApiServices.Abstract;

namespace BlogFrontend.ApiServices.Concrete{
    public class ImageApiManager : IImageApiService{
        private readonly HttpClient _httpClient;
        public ImageApiManager(HttpClient httpClient)
        {
            _httpClient=httpClient;
            _httpClient.BaseAddress= new Uri("http://localhost:64061/api/images/");
        }

        public async Task<string> GetBlogImageByIdAsync(int id){
            
            var responseMessage = await _httpClient.GetAsync($"GetBlogImageId/{id}");
             if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }
            return null;
        }
    }
}