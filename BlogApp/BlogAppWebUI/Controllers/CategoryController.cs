using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(categoryRepository.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category entity)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.AddCategory(entity);
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult AddOrUpdate(int id)
        {
            if (id==null)
            {
                return View();
            }
            else
            {
                
                return View(categoryRepository.getById(id));
            }
            
        }
        [HttpPost]
        public IActionResult AddOrUpdate(Category entity)
        {
            if(ModelState.IsValid)
            {
                categoryRepository.AddOrUpdate(entity);
                return RedirectToAction("List");
            }
            return View(entity);

        }
    }
}
