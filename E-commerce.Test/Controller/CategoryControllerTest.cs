using E_commerce.Controllers;
using E_commerce.Data.ViewModels;
using E_commerce.Test.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace E_commerce.Test.Controller
{
    public class CategoryControllerTest 
	{
		[Fact]
		public void GetCategoryByID_Test()
		{
			//Arrange
			var mockCategory = new CategoryVM()
			{
				Id = 2,
				Name = "Lily"
			};
			var mockProductServie = new MockCategoryService().MockById(mockCategory, 2);
			var controller = new CategoriesController(mockProductServie.Object);

			//Act
			var result = controller.GetCategoryByID(2);

			//Assert
			Assert.IsAssignableFrom<IActionResult>(result);
			mockProductServie.VerifyGetById(Times.Once(), 2);
		}
	}
}
