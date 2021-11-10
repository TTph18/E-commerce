using E_commerce.Data.Models;
using E_commerce.Data.ViewModels;
using E_commerce.Shared.DTO.Paging;
using E_commerce.Shared.DTO.Product;
using E_commerce.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public interface IProductsService
    {
        Task<Products> AddProductWithCategoryAsync(ProductCreateRequest request);
        Task<PagingResponseDTO<ProductDTO>> GetProducts(
            ProductCriteriaDTO productCriteriaDto, CancellationToken cancellationToken);
        ProductVM GetProductByID(int productID);
        Task<Products> UpdateProductByIDAsync(int productID, ProductCreateRequest request);
        Task UpdateRatingByIDAsync(int productID);
        Products DeleteProductByID(int productID);

    }
}
