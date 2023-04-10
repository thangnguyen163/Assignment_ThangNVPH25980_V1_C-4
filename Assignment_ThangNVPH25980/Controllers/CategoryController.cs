using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Models;
using Assignment_ThangNVPH25980.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ThangNVPH25980.Controllers
{
    public class CategoryController : Controller
    {
        private readonly OuteDBContext context;
        private readonly ICategoryServices categoryServices;
        public CategoryController()
        {
            context = new OuteDBContext();
            categoryServices = new CategoryServices();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowList()
        {
            List<Category> c = categoryServices.GetAllCategory();
            ViewBag.Categorys = c;
            return View();
        }
        public IActionResult Details(Guid Id)
        {
            var c = context.Category.Find(Id);
            return View(c);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category c)
        {
            if (categoryServices.Add(c))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var color = categoryServices.GetCategoryById(Id);
            return View(color);
        }
        public IActionResult Edit(Category c)
        {
            if (categoryServices.Add(c))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

        public IActionResult Delete(Guid Id)
        {
            if (categoryServices.Delete(Id))
                return RedirectToAction("ShowList");
            return BadRequest();
        }
    }
}
