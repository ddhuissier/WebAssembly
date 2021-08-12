﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssemblyApp.Shared.Models;

namespace WebAssemblyApp.Client.ViewModels.Contracts
{
    public interface IRadzenViewModel
    {
        public List<Product> Products { get; set; }

        public Task GetProducts();
        public Task GetProduct(int id);
    }
}
