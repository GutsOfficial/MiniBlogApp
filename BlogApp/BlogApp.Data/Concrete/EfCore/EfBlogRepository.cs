using BlogApp.Data.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfBlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;
        public EfBlogRepository(BlogContext context)
        {
            _context = context;
        }
        public void AddBlog(Blog entity)
        {
            _context.Add(entity);  
            _context.SaveChanges();
        }

        public void DeleteBlog(int BlogId)
        {
            var blog = _context.Blogs.FirstOrDefault(p=>p.BlogId==BlogId);
            
            if (blog != null)
            {
                _context.Remove(blog);
                _context.SaveChanges(); 
            }
        }

        public IQueryable<Blog> GetAll()
        {
            return _context.Blogs;
        }

        public Blog GetById(int BlogId)
        {
            return _context.Blogs.FirstOrDefault(p => p.BlogId == BlogId);
        }

        public void SaveBlog(Blog entity)
        {
            if (entity.BlogId==0)
            {
                entity.Date = DateTime.Now;
                _context.Blogs.Add(entity);
            }
            else
            {
                var blog = GetById(entity.BlogId);
                if (blog != null)
                {
                    blog.Title = entity.Title;
                    blog.Description = entity.Description;
                    blog.Body = entity.Body;
                    blog.CategoryId = entity.CategoryId;
                    blog.Image = entity.Image;
                    blog.IsApproved = entity.IsApproved;
                    blog.IsHome= entity.IsHome;
                    blog.IsSlider = entity.IsSlider;
                }
            }
            _context.SaveChanges();
        }

        public void UpdateBlog(Blog entity)
        {
            var blog = GetById(entity.BlogId);
            if (blog!=null)
            {
                blog.Title = entity.Title;
                blog.Description = entity.Description;
                blog.Body= entity.Body;
                blog.CategoryId = entity.CategoryId;
                blog.Image = entity.Image;
            }
            _context.SaveChanges();
        }
    }
}
