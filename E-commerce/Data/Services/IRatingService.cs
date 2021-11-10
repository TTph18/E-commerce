using E_commerce.Data.Models;
using E_commerce.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public interface IRatingService
    {
        Task AddRatingWithProductAsync(RatingCreateRequest request);
        List<ProductRating> GetRatingByProducts(int productID);
    }
}
