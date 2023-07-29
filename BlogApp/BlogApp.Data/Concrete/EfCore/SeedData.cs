using BlogApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>();
            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category() { Name="Category 1"},
                     new Category() { Name = "Category 2" },
                      new Category() { Name = "Category 3" }
                    );
            }
            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog { Title="New Title 1",Description="Merhabalar",
                    Body="body 1",Image="guts.jpg",Date=DateTime.Now.AddDays(-4),IsApproved=true,CategoryId=1},
                    new Blog
                    {
                        Title = "New Title 2",
                        Description = "Merhabalar",
                        Body = "body 2",
                        Image = "guts.jpg",
                        Date = DateTime.Now.AddDays(-4),
                        IsApproved = true,
                        CategoryId = 2
                    },
                    new Blog
                    {
                        Title = "New Title 3",
                        Description = "Merhabalar",
                        Body = "body 3",
                        Image = "guts.jpg",
                        Date = DateTime.Now.AddDays(-4),
                        IsApproved = false,
                        CategoryId = 3
                    },
                    new Blog
                    {
                        Title = "New Title 4",
                        Description = "Merhabalar",
                        Body = "body 4",
                        Image = "guts.jpg",
                        Date = DateTime.Now.AddDays(-4),
                        IsApproved = true,
                        CategoryId = 4
                    }
                    );
                SeedData.Seed(app);
                     
            }
        }
    }
}
