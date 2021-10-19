using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Helpers
{
    public class WebHostHelper
    {
        public static string GetWebRootPath()
        {
            var _accessor = new HttpContextAccessor();

            return _accessor.HttpContext
                                .RequestServices
                                .GetRequiredService<IWebHostEnvironment>()
                                .WebRootPath;
        }

        public static string GetWebUrl()
        {
            var _accessor = new HttpContextAccessor();

            return _accessor.HttpContext
                               .RequestServices
                               .GetRequiredService<IConfiguration>()
                               .GetValue<string>("EndPoints:BackEnd");
        }
    }
}
