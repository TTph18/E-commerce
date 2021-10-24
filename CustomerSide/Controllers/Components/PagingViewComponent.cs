using CustomerSide.Models;
using E_commerce.Shared;
using E_commerce.Shared.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSide.Controllers.Components
{
    public class PagingViewComponnet : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PaginatedList<ProductsViewModel> result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
