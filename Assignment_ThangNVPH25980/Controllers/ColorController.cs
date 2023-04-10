using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Models;
using Assignment_ThangNVPH25980.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ThangNVPH25980.Controllers
{
    public class ColorController : Controller
    {
        private readonly OuteDBContext context;
        private readonly IColorServices colorServices;
        public ColorController()
        {
            context = new OuteDBContext();
            colorServices = new ColorServices();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowList()
        {
            List<Color> colors = colorServices.GetAllColor();
            ViewBag.Colors = colors;
            return View();
        }
        public IActionResult Details(Guid Id)
        {
            var colors = context.Color.Find(Id);
            return View(colors);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Color color)
        {
            if (colorServices.Add(color))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var color = colorServices.GetColorById(Id);
            return View(color);
        }
        public IActionResult Edit(Color color)
        {
            if (colorServices.Add(color))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

        public IActionResult Delete(Guid Id)
        {
            if (colorServices.Delete(Id))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

    }
}
