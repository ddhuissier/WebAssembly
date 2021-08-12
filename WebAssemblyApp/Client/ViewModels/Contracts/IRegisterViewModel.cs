using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Client.ViewModels.Contracts
{
    public interface IRegisterViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ReenterPassword { get; set; }


        public Task RegisterUser();
    }
}