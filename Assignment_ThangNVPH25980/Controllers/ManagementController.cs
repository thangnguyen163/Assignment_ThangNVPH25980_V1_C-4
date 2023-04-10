using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Models;
using Assignment_ThangNVPH25980.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ThangNVPH25980.Views
{
    public class ManagementController : Controller
    {
        private readonly IProductServices productServices;
        private readonly OuteDBContext context;
        private readonly IColorServices colorServices;
        private readonly ISizeServices sizeServices;
        private readonly ICategoryServices categoryServices;
        public ManagementController()
        {
            productServices=new ProductServices();
            context=new OuteDBContext();
            colorServices=new ColorServices();
            sizeServices=new SizeServices();    
            categoryServices=new CategoryServices();    
        }
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult ProductList()
        {
            List<Products> products = productServices.GetAllProducts();
            //List<ProductView> products = productServices.GetAllProductView();
            ViewBag.Products = products;
            var lst = context.Products.Include("Size").Include("Color").Include("Category").ToList();
            return View(lst);
            
        }
        public IActionResult Details(Guid Id)
        {
            OuteDBContext context = new OuteDBContext();
            var product = context.Products.Include("Size").Include("Color").Include("Category").FirstOrDefault(x => x.Id == Id);
            return View(product);
        }
        public IActionResult AddProduct()
        {
            List<Color> colors = colorServices.GetAllColor();
            List<Size> sizes = sizeServices.GetAllSize();
            List<Category> categories= categoryServices.GetAllCategory();
            ViewBag.Colors = colors;
            ViewBag.Sizes = sizes;
            ViewBag.Categories = categories;
            return View();
        }
        public IActionResult DetailProduct(Guid Id)
        {
            var product = context.Products.Find(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Products products, [Bind] IFormFile ImageFile)
        {
            var x = ImageFile.FileName;
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", ImageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
            }
            products.Image = ImageFile.FileName;
            if (productServices.Add(products))
                return RedirectToAction("ProductList");
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditProduct(Guid Id)
        {
            List<Color> colors = colorServices.GetAllColor();
            List<Size> sizes = sizeServices.GetAllSize();
            List<Category> categories = categoryServices.GetAllCategory();
            ViewBag.Colors = colors;
            ViewBag.Sizes = sizes;
            ViewBag.Categories = categories;
            var product = productServices.GetProductsById(Id);
            return View(product);
        }

        public IActionResult EditProduct(Products p, [Bind] IFormFile ImageFile)
        {
            var x = ImageFile.FileName;
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", ImageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
            }
            p.Image = ImageFile.FileName;
            if (productServices.Update(p))
                return RedirectToAction("ProductList");
            else return BadRequest();
        }

    }
}
