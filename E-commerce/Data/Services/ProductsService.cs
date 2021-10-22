using E_commerce.Data.ViewModels;
using E_commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using E_commerce.Data.Paging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using E_commerce.Data.Services.FileStorage;

namespace E_commerce.Data.Services
{
    public class ProductsService
    {
        private AppDBContext _context;
        private readonly IFileStorageService _fileStorageService;
        public ProductsService(AppDBContext context, IFileStorageService fileStorageService)
        {
            _context = context;
            _fileStorageService = fileStorageService;
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
                var _image = await _fileStorageService.SaveFileAsync(request.ImageFile);
                _product.PictureUrl = _fileStorageService.GetFileUrl(_image);
            }
            _context.Products.Add(_product);
            await _context.SaveChangesAsync();
            return _product;
        }
        public List<Products> GetAllProduct(string sortBy, string filterString, int? pageNumber) 
        { 
            var allProducts = _context.Products.ToList();
            var allCategories = _context.Categories.ToList();

            //Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                        allProducts = allProducts.OrderByDescending(n => n.Name).ToList();
                        break;
                    case "name_asc":
                        allProducts = allProducts.OrderBy(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            //Filtering
            if (!string.IsNullOrEmpty(filterString))
            {
                var filterCategory = allCategories.Where(n => n.Name.Contains(filterString, 
                    StringComparison.CurrentCultureIgnoreCase)).
                    FirstOrDefault();
                allProducts = allProducts.Where(n => n.CategoryID.Equals(filterCategory.Id)).ToList();
            }

            //Paging
            int pageSize = 4;
            allProducts = PaginatedList<Products>.Create(allProducts.AsQueryable(), pageNumber ?? 1, pageSize);

            return allProducts;
        }
        public Products GetProductByID(int productID) => _context.Products.FirstOrDefault(n => n.Id == productID);
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
                var _image = await _fileStorageService.SaveFileAsync(request.ImageFile);
                _product.PictureUrl = _fileStorageService.GetFileUrl(_image);
            }
            _context.Products.Update(_product);
            await _context.SaveChangesAsync();
            return _product;
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
    }
}
