using E_commerce.Data.Models;
using E_commerce.Data.ViewModels;
using E_commerce.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public class RatingService
    {
        private AppDBContext _context;
        public ProductsService _productsService;

        public RatingService(AppDBContext context, ProductsService productsService)
        {
            _context = context;
            _productsService = productsService;
        }
        public async Task AddRatingWithProductAsync(RatingCreateRequest request)
        {
            var rating = new ProductRating
            {
                ProductID = request.ProductID,
                Rating = request.Rating
            };
            _context.ProductRatings.Add(rating);
            _context.SaveChanges();
            await _productsService.UpdateRatingByIDAsync(request.ProductID);
        }
        public List<ProductRating> GetRatingByProducts(int productID)
        {
            var productRatings = _context.ProductRatings.Where(n => n.ProductID == productID).ToList();
            return productRatings;
        }
    }
}
