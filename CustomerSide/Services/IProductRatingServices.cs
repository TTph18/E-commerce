using E_commerce.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSide.Services
{
    public interface IProductRatingServices
    {
        Task<bool> AddRatingByProductAsync(int productID, ProductRatingVM productRating);
    }
}
