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
                
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new Categories()
                    {
                        Name = "Rose"
                    },
                    new Categories()
                    {
                        Name = "Lily"
                    },
                    new Categories()
                    {
                        Name = "Camellia"
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new Products()
                    {
                        Name = "Bonnie Marie",
                        Description = "First flower",
                        Price = 20.001f,
                        PictureUrl = "https....",
                        CategoryID = 3
                    },
                    new Products()
                    {
                        Name = "Glaze Lily",
                        Description = "Second flower",
                        Price = 2.001f,
                        PictureUrl = "https....",
                        CategoryID = 2
                    },
                    new Products()
                    {
                        Name = "Tulip",
                        Description = "Lily flower",
                        Price = 2.081f,
                        PictureUrl = "https....",
                        CategoryID = 2
                    },
                    new Products()
                    {
                        Name = "Erythronium",
                        Description = "Lily flower",
                        Price = 2.881f,
                        PictureUrl = "https....",
                        CategoryID = 2
                    },
                    new Products()
                    {
                        Name = "Crimson Rose",
                        Description = "Second flower",
                        Price = 2.001f,
                        PictureUrl = "https....",
                        CategoryID = 1
                    },
                    new Products()
                    {
                        Name = "Acaena Rose",
                        Description = "Rose flower",
                        Price = 3.001f,
                        PictureUrl = "https....",
                        CategoryID = 1
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
