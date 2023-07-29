using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppWebUI.ViewComponents
{
    public class CategoryMenuViewComponent:ViewComponent
    {
        private ICategoryRepository categoryRepository;
        public CategoryMenuViewComponent(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.selectedcategory = RouteData?.Values["id"];
            return View(categoryRepository.GetAll());
        }
    }
}
