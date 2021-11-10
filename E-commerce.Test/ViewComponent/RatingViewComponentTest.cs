using CustomerSide.Controllers.Components;
using CustomerSide.Services;
using E_commerce.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace E_commerce.Test.ViewComponent
{
    public class RatingViewComponentTest
    {
        [Fact]
        public void GetRating_Success()
        {
            //Arrange ViewComponent
            var httpContext = new DefaultHttpContext();
            var viewContext = new ViewContext();
            viewContext.HttpContext = httpContext;
            var viewComponentContext = new ViewComponentContext();
            viewComponentContext.ViewContext = viewContext;

            //Arrange Mock
            var ratingyApiMock = new Mock<IProductRatingServices>();
            ratingyApiMock.Setup(c => c.GetRatingsAsync(1)).Returns(getProductRatingValue());
            var viewComponent = new RatingViewComponent(ratingyApiMock.Object);

            //Act Check final result is ViewComponent
            var result = viewComponent.InvokeAsync(1);
            var createdAtActionResult = Assert.IsType<Task<IViewComponentResult>>(result);
        }
        private Task<List<ProductRatingVM>> getProductRatingValue()
        {
            List<ProductRatingVM> ratingValue = new List<ProductRatingVM>();
            return Task.FromResult(ratingValue);
        }
    }
}
