using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlogFrontend.ApiServices.Abstract;
using BlogFrontend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogFrontend.ApiServices.Concrete{
    public class AuthApiManager :IAuthApiService{
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        public AuthApiManager(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("http://localhost:64061/api/auth/");
        }
        public async Task<bool> SignIn(UserLoginModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("SignIn", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var accessToken = JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());

                _httpContextAccessor.HttpContext.Session.SetString("token",accessToken.Token);

                return true;
            }
            return false;
        }
    }
}