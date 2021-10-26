using E_commerce.Shared.DTO.Paging;
using E_commerce.Shared.DTO.Product;
using E_commerce.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSide.Services
{
    public interface IProductServices
    {
        Task<PagingResponseDTO<ProductDTO>> GetProductsAsync(ProductCriteriaDTO productCriteriaDto);
        Task<ProductVM> GetProductByIDAsync(int productID);
    }
}
