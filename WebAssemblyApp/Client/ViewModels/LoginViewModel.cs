using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebAssemblyApp.Client;
using WebAssemblyApp.Shared;
using WebAssemblyApp.Shared.Models;
using WebAssemblyApp.Client.ViewModels.Contracts;
using WebAssemblyApp.WebAPI.Models;

namespace WebAssemblyApp.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        private HttpClient _httpClient;
        public LoginViewModel()
        {

        }
        public LoginViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoginUser()
        {
            await _httpClient.PostAsJsonAsync<User>("user/loginuser", this);
        }

        public static implicit operator LoginViewModel(User user)
        {
            return new LoginViewModel
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };
        }

        public static implicit operator User(LoginViewModel loginViewModel)
        {
            return new User
            {
                EmailAddress = loginViewModel.EmailAddress,
                Password = loginViewModel.Password
            };
        }
    }
}