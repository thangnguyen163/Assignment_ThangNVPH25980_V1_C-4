using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Models;
using Assignment_ThangNVPH25980.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ThangNVPH25980.Controllers
{
    public class SizeController : Controller
    {
        private readonly OuteDBContext context;
        private readonly ISizeServices sizeServices;
        public SizeController()
        {
            context = new OuteDBContext();
            sizeServices = new SizeServices();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowList()
        {
            List<Size> Size = sizeServices.GetAllSize();
            ViewBag.Sizes = Size;
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
        public IActionResult Add(Size Size)
        {
            if (sizeServices.Add(Size))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var color = sizeServices.GetSizeById(Id);
            return View(color);
        }
        public IActionResult Edit(Size Size)
        {
            if (sizeServices.Add(Size))
                return RedirectToAction("ShowList");
            return BadRequest();
        }

        public IActionResult Delete(Guid Id)
        {
            if (sizeServices.Delete(Id))
                return RedirectToAction("ShowList");
            return BadRequest();
        }
    }
}
