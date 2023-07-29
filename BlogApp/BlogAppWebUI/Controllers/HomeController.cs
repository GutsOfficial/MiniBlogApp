using BlogApp.Data.Abstract;
using BlogAppWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppWebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;
        public HomeController(IBlogRepository repository)
        {
            blogRepository= repository;
        }
        public IActionResult Index()
        {
            HomeBlogModel model =new HomeBlogModel();
            model.HomeBlogs = blogRepository.GetAll().Where(x => x.IsApproved  && x.IsHome ).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(x => x.IsApproved == true && x.IsSlider == true).ToList();
            return View(model);
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
