using E_commerce.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new Products()
                    {
                        Name = "Camellia",
                        Description = "First flower",
                        Price = 20.001f,
                        PictureUrl = "https...."
                    },
                    new Products()
                    {
                        Name = "Lily",
                        Description = "Second flower",
                        Price = 2.001f,
                        PictureUrl = "https...."
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
