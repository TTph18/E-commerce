using E_commerce.Data.ViewModels;
using E_commerce.Data.Models;
using E_commerce.Shared.DTO.Product;
using E_commerce.Shared.DTO.Paging;
using E_commerce.Data.Services.FileStorage;
using E_commerce.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using E_commerce.Shared.ViewModels;

namespace E_commerce.Data.Services
{
    public class ProductsService : IProductsService
    {
        private AppDBContext _context;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public ProductsService(AppDBContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            _context = context;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }
        public async Task<Products> AddProductWithCategoryAsync(ProductCreateRequest request)
        {
            var _product = new Products()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryID = request.CategoryID,
                PictureUrl = string.Empty
            };
            if (request.ImageFile != null)
            {
                _product.PictureUrl = await _fileStorageService.SaveFileAsync(request.ImageFile);
            }
            _context.Products.Add(_product);
            await _context.SaveChangesAsync();
            return _product;
        }
        public async Task<PagingResponseDTO<ProductDTO>> GetProducts(
            ProductCriteriaDTO productCriteriaDto, CancellationToken cancellationToken) 
        {
            var productQuery = _context
                                    .Products
                                    .AsQueryable();

            productQuery = ProductFilter(productQuery, productCriteriaDto);

            var pageProducts = await productQuery
                                        .AsNoTracking()
                                        .PaginateAsync(productCriteriaDto, cancellationToken);

            var productDto = _mapper.Map<IEnumerable<ProductDTO>>(pageProducts.Items);
            return new PagingResponseDTO<ProductDTO>
            {
                CurrentPage = pageProducts.CurrentPage,
                TotalPages = pageProducts.TotalPages,
                TotalItems = pageProducts.TotalItems,
                Search = productCriteriaDto.Search,
                SortColumn = productCriteriaDto.SortColumn,
                SortOrder = productCriteriaDto.SortOrder,
                Limit = productCriteriaDto.Limit,
                Items = productDto
            };
        }
        public ProductVM GetProductByID(int productID) 
        { 
            var product = _context.Products.FirstOrDefault(n => n.Id == productID);
            var productViewModel = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Rate = product.Rate,
            };
            return productViewModel;
        } 
       
        public async Task<Products> UpdateProductByIDAsync(int productID, ProductCreateRequest request)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == productID);
            if(_product != null)
            {
                _product.Name = request.Name;
                _product.Description = request.Description;
                _product.Price = request.Price;
                _product.CategoryID = request.CategoryID;
                
            }
            if (request.ImageFile != null)
            {
                _product.PictureUrl = await _fileStorageService.SaveFileAsync(request.ImageFile);
            }
            _context.Products.Update(_product);
            await _context.SaveChangesAsync();
            return _product;
        }
        public async Task UpdateRatingByIDAsync(int productID)
        {
            int totalRate = 0;
            int avgRate = 0;
            var _productRating = _context.ProductRatings.Where(n => n.ProductID == productID).ToList();
            if (_productRating != null)
            {
                foreach (var item in _productRating)
                {
                    totalRate += item.Rating;
                }
                avgRate = (int) Math.Round((double)totalRate / _productRating.Count());
            }
            var _product = _context.Products.FirstOrDefault(n => n.Id == productID);
            _product.Rate = avgRate;
            _context.Attach(_product);
            _context.Entry(_product).Property(r => r.Rate).IsModified = true;
            await _context.SaveChangesAsync();
        }
        public Products DeleteProductByID(int productID)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == productID);
            if (_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
            return _product;
        }
        private IQueryable<Products> ProductFilter(
            IQueryable<Products> productQuery,
            ProductCriteriaDTO productCriteriaDto)
        {
            if (!String.IsNullOrEmpty(productCriteriaDto.Search))
            {
                productQuery = productQuery.Where(b =>
                    b.Name.Contains(productCriteriaDto.Search, 
                    StringComparison.CurrentCultureIgnoreCase));
            }
            return productQuery;
        }
    }
}
