using Azure.Core;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly BlogContext _context;
        public EfCategoryRepository(BlogContext context)
        {
            _context = context;
        }
        public void AddCategory(Category entity)
        {
           _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void AddOrUpdate(Category entity)
        {
            if (entity.CategoryId == 0)
            {

                _context.Categories.Add(entity);
            }
            else
            {
                var category = getById(entity.CategoryId);
                if (category != null)
                {

                    category.Name = entity.Name;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(p=>p.CategoryId== categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category getById(int categoryId)
        {
            return  _context.Categories.FirstOrDefault(c=>c.CategoryId== categoryId);
        }

        public void UpdateCategory(Category entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
