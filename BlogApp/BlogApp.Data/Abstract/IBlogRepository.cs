using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Abstract
{
    public interface IBlogRepository
    {
        IQueryable<Blog> GetAll();
        Blog GetById(int BlogId);
        void AddBlog(Blog entity);
        void UpdateBlog(Blog entity);
        void DeleteBlog(int BlogId);
        void SaveBlog(Blog entity);
    }
}
