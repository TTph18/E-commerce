using E_commerce.Data.Models;
using E_commerce.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public class RatingService
    {
        private AppDBContext _context;
        public RatingService(AppDBContext context)
        {
            _context = context;
        }
        public void AddRatingWithProduct(RatingCreateRequest request)
        {
            var rating = new ProductRating
            {
                ProductID = request.ProductID,
                Rating = request.ProductID
            };
            _context.ProductRatings.Add(rating);
            _context.SaveChanges();
        }
        public List<ProductRating> GetRatingByProducts(int productID)
        {
            var productRatings = _context.ProductRatings.Where(n => n.Id == productID).ToList();
            return productRatings;
        }
    }
}
