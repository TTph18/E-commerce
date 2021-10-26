using E_commerce.Shared.DTO.Paging;
using E_commerce.Shared.DTO.Product;
using E_commerce.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSide.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IConfiguration _configuration;

        public ProductServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<PagingResponseDTO<ProductDTO>> GetProductsAsync(ProductCriteriaDTO productCriteriaDto)
        {
            var productList = new PagingResponseDTO<ProductDTO>();

            var Search = productCriteriaDto.Search;
            var SortOrder = productCriteriaDto.SortOrder;
            var SortColumn = productCriteriaDto.SortColumn;
            var Page = productCriteriaDto.Page;
            var Limit = productCriteriaDto.Limit;
            var queryString = $"Search={Search}&SortOrder={SortOrder}&SortColumn={SortColumn}&Limit={Limit}&Page={Page}";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/Products/get-all-products?" + queryString))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<PagingResponseDTO<ProductDTO>>(apiResponse);
                }
            }
            return productList;
        }
        public async Task<ProductVM> GetProductByIDAsync(int productID)
        {
            ProductVM product = new ProductVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/Products/get-product-by-id/" + productID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<ProductVM>(apiResponse);
                }
            }
            return product;
        }
    }
}
