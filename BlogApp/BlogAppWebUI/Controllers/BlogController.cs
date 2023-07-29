using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BlogAppWebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository blogRepository;
        private readonly ICategoryRepository categoryRepository;
        public BlogController(IBlogRepository repository, ICategoryRepository categoryRepo)
        {
            blogRepository = repository;
            categoryRepository = categoryRepo;
        }
        public IActionResult Index(int? id,string q)
        {
            var query = blogRepository.GetAll().Where(x => x.IsApproved == true);
            if (id!=null)
            {
                query = query.Where(i => i.CategoryId == id);
               
            }
            if (!string.IsNullOrEmpty(q))
             {
                query = query.Where(i => EF.Functions.Like(i.Title, "%" + q + "%"
                    )|| EF.Functions.Like(i.Description, "%" + q + "%")
                    || EF.Functions.Like(i.Body, "%" + q + "%"));
                
            }
            return View(query) ;
        }
        public IActionResult List()
        {
            return View(blogRepository.GetAll());
        }
       public IActionResult AddOrUpdate(int id) {

            ViewBag.category = new SelectList(categoryRepository.GetAll(), "CategoryId", "Name");
            if (id == null)
            {
                //yeni kayıt
                return View();
            }
            else
            {

                return View(blogRepository.GetById(id));
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(Blog entity,IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                if (file!=null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    entity.Image = file.FileName;
                }
              
                    blogRepository.SaveBlog(entity);
                return RedirectToAction("List");
            }
            ViewBag.category = new SelectList(categoryRepository.GetAll(), "CategoryId", "Name");

            return View(entity);
        }
        public IActionResult Delete(int id) {


            return View(blogRepository.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Deleted(int id) 
        {
            blogRepository.DeleteBlog(id);
            return RedirectToAction("List");
        
        }
        public IActionResult Details(int id)
        {
            
            return View(blogRepository.GetById(id));
        }

    }
}
