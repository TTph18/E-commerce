using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using CustomerSide.Models;
using E_commerce.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce.Shared.Enum;
using E_commerce.Shared.DTO.Product;
using E_commerce.Shared.DTO.Paging;
using System.Net.Http;
using Newtonsoft.Json;
using CustomerSide.Services;

namespace CustomerSide.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public IndexModel(
            IMapper mapper,
            IProductServices productServices
            )
        {
            _mapper = mapper;
            _productServices = productServices;
        }

        public PagingResponseVM<ProductVM> Products { get; set; }
        public async Task OnGetAsync(SortOrderEnum sortOrder, string currentFilter, string searchString, int? pageIndex, int? limit)
        {
            var productCriteriaDto = new ProductCriteriaDTO()
            {
                Search = searchString,
                SortOrder = sortOrder,
                SortColumn = currentFilter,
                Page = pageIndex ?? 1,
                Limit = limit ?? 10,
            };
            var pagedProducts = await _productServices.GetProductsAsync(productCriteriaDto);
            Products = _mapper.Map<PagingResponseVM<ProductVM>>(pagedProducts);
        }
        
    }
}
