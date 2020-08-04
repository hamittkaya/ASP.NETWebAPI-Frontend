using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlogFrontend.ApiServices.Abstract;
using BlogFrontend.Extensions;
using BlogFrontend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogFrontend.ApiServices.Concrete{
    public class ArticleApiManager : IArticleApiService
    {
         private readonly HttpClient _httpClient;
         private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticleApiManager(HttpClient httpClient,IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:64061/api/articles/");
            _httpContextAccessor=httpContextAccessor;
        }
        public async Task<List<ArticleListModel>> GetAllAsync()
        {
            var responseMessage= await _httpClient.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ArticleListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ArticleListModel> GetByIdAsync(int id)
        {
            var responseMessage= await _httpClient.GetAsync($"{id}");
             if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticleListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
         public async Task<List<ArticleListModel>> GetAllByCategoryIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetAllByCategoryId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ArticleListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task AddAsync(ArticleAddModel model)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            if (model.Image != null)
            {
                var bytes = await System.IO.File.ReadAllBytesAsync(model.Image.FileName);
                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);

                formData.Add(byteContent, nameof(ArticleAddModel.Image), model.Image.FileName);
            }

            var user = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>(null);
            model.UserId=user.UserId;

            formData.Add(new StringContent(model.UserId.ToString()), nameof(ArticleAddModel.UserId));
           
            formData.Add(new StringContent(model.ShortDescription), nameof(ArticleAddModel.ShortDescription));

            formData.Add(new StringContent(model.Description),nameof(ArticleAddModel.Description));

            formData.Add(new StringContent(model.Title),nameof(ArticleAddModel.Title));

           // _httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer",_httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync("",formData);
        }

         public async Task UpdateAsync(ArticleUpdateModel model)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            if (model.Image != null)
            {
                var bytes = await System.IO.File.ReadAllBytesAsync(model.Image.FileName);
                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);

                formData.Add(byteContent, nameof(ArticleAddModel.Image), model.Image.FileName);
            }

            var user = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>(null);
            model.UserId=user.UserId;
            formData.Add(new StringContent(model.ArticleId.ToString()),nameof (ArticleUpdateModel.ArticleId));

            formData.Add(new StringContent(model.UserId.ToString()), nameof(ArticleAddModel.UserId));
           
            formData.Add(new StringContent(model.ShortDescription), nameof(ArticleAddModel.ShortDescription));

            formData.Add(new StringContent(model.Description),nameof(ArticleAddModel.Description));

            formData.Add(new StringContent(model.Title),nameof(ArticleAddModel.Title));

           // _httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer",_httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"{model.ArticleId}",formData);
        }

        
        public async Task DeleteAsync(int id){
            await _httpClient.DeleteAsync($"{id}");
        }


       
    }
}