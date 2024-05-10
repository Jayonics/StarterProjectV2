﻿using System.Net.Http.Json;
using Shop.Models.Dtos;
using Shop.WebApp.Services.Contracts;

namespace Shop.WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var products = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
                return products;
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }
    }
}
