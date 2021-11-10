using E_commerce.Data.Models;
using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Test.Service
{
	public class MockCategoryService : Mock<ICategoriesService>
	{
		public MockCategoryService MockById(CategoryVM result, int categoryId)
		{
            Setup(x => x.GetCategoryByID(categoryId))
				.Returns(result);
			return this;
		}
		public MockCategoryService VerifyGetById(Times times, int categoryId)
		{
			Verify(x => x.GetCategoryByID(categoryId), times);

			return this;
		}
	}
}
