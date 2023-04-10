using Assignment_ThangNVPH25980.IService;
using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Models;
using Assignment_ThangNVPH25980.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics; 

namespace Assignment_ThangNVPH25980.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices;
        private readonly IColorServices colorServices;
        private readonly ISizeServices sizeServices;
        private readonly ICategoryServices categoryServices;
        private readonly IAccountServices accountServices;
        private readonly ICartDetailServices cartDetailServices;
        private readonly IBillServices billServices;
        private readonly IBillDeatailServices billDeatailServices;
        private readonly OuteDBContext context;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices(); 
            colorServices = new ColorServices();
            sizeServices = new SizeServices();
            categoryServices = new CategoryServices();
            accountServices = new AccountServices();
            cartDetailServices=new CartDetailServices();
            context = new OuteDBContext();
            billDeatailServices = new BillDeatailServices();
            billServices=new BillServices();

        }

        public IActionResult Index()
        {
            string user = HttpContext.Session.GetString("User");
            var users = JsonConvert.DeserializeObject<Accounts>(user);
            ViewBag.User = users;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Products()
        {
            List<Products> products = productServices.GetAllProducts();
            //List<ProductView> products = productServices.GetAllProductView();
            ViewBag.Products = products;
            return View();
        }

        [HttpGet]
        public IActionResult Detail(Guid Id)
        {
            OuteDBContext context = new OuteDBContext();
            var product = context.Products.Include("Size").Include("Color").Include("Category").FirstOrDefault(x=>x.Id==Id);
            List<Color> colors = colorServices.GetAllColor();
            List<Size> sizes = sizeServices.GetAllSize();
            List<Category> categories = categoryServices.GetAllCategory();
            ViewBag.Colors = colors;
            ViewBag.Sizes = sizes;
            ViewBag.Categories = categories;
            return View(product);

            //return View(productServices.GetProductsById(Id));
        }
        #region Bill PayToBill
        public IActionResult Bill()
        {
            List<BillDetails> billDetails = billDeatailServices.GetAllBillDetail();
            List<Bill> bills = context.Bill.Include("Accounts").Include("BillDetails").ToList();
            ViewBag.BillDetails = billDetails;
            ViewBag.Bills = bills;
            return View();
        }
        [HttpPost]
        public IActionResult PayToBill()
        {
            string user = HttpContext.Session.GetString("User");
            if (user == null)
            {
                return RedirectToAction("Login");

            }
            Accounts users = JsonConvert.DeserializeObject<Accounts>(user);

            var list = cartDetailServices.GetAllCartDetails().Where(x => x.UserId == users.Id);
            //Nếu giỏ hàng chưa có đồ thì bắt mua
            if (list.Count() == 0)
            {
                return RedirectToAction("Products");
            }
            else
            {
                Guid id = Guid.NewGuid();
                //Nếu giỏ hàng có đồ thì tạo hóa đơn, hóa đơn chi tiết và xóa dữ liệu trong giỏ hàng 
                Bill bill = new Bill()
                {
                    Id = id,
                    CreatedDate = DateTime.Now,
                    UserId = users.Id,
                    Status = 1,
                };
                billServices.Add(bill);
                var listCartDetail = cartDetailServices.GetAllCartDetails().Where(x => x.UserId == users.Id).ToList(); //danh sách giỏ hàng
                for (int i = 0; i < listCartDetail.Count(); i++)
                {
                    var Product = productServices.GetProductsById(listCartDetail[i].ProductId);//lấy ra 1 sản phẩm;
                    var cartdetail = cartDetailServices.GetAllCartDetails().FirstOrDefault(x => x.ProductId == Product.Id && x.UserId == users.Id);//lấy ra thằng giỏ hàng chi tiết để lấy số lượng
                    BillDetails billDetail = new BillDetails();
                    billDetail.Id = Guid.NewGuid();
                    billDetail.BillId = id;
                    billDetail.ProductId = Product.Id;
                    billDetail.Quantity = cartdetail.Quantity;
                    billDetail.Price = cartdetail.Quantity * Product.Price;
                    billDeatailServices.Add(billDetail);
                    //Add 1 sản phẩm vào bill detail
                    //Sau đó Update số lượng
                    Product.AvailableQuantity = Product.AvailableQuantity - cartdetail.Quantity;
                    productServices.Update(Product);
                    //Xóa ở CartDetail
                    cartDetailServices.Delete(cartdetail.Id);
                }
                return RedirectToAction("Bill");
            }

        }
        #endregion


        public IActionResult BillDetail(Guid billId)
        {
            
            List<BillDetails> billDetails = context.BillDetails.Include("Product").Where(x=>x.BillId==billId).ToList();
            ViewBag.BillDetail=billDetails;

            List<Products> products = context.Products.Include("Size").Include("Color").Include("Category").ToList();
            ViewBag.Products=products;
            return  View();
        }

        #region AddToCart   Cart
        public IActionResult Cart()
        {
            string user = HttpContext.Session.GetString("User");
            Accounts users = JsonConvert.DeserializeObject<Accounts>(user);
            List<CartDetails> cartDetails = cartDetailServices.GetAllCartDetails().Where(x => x.UserId == users.Id).ToList();
            List<Products> products = context.Products.Include("Size").Include("Color").Include("Category").ToList();
            ViewBag.CartDetail = cartDetails;
            ViewBag.Pro = products;
            return View();
        }
        [HttpPost]
        public IActionResult Cart(Guid IdPro)
        {

            string user = HttpContext.Session.GetString("User");
            Accounts users = JsonConvert.DeserializeObject<Accounts>(user);
            List<CartDetails> cartDetails = cartDetailServices.GetAllCartDetails().Where(x => x.UserId == users.Id && x.ProductId == IdPro).ToList();
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                // List<Cart> Carts =_cartService.GetAllCarts().Where(x => x.UserId == users.Id).ToList();
                if (cartDetails.Count == 0)
                {
                    CartDetails cartDetail = new CartDetails()
                    {
                        Id = Guid.NewGuid(),
                        UserId = users.Id,
                        ProductId = IdPro,
                        Quantity = 1,
                    };
                    cartDetailServices.Add(cartDetail);

                }
                else
                {
                    CartDetails cartDetail = new CartDetails();
                    cartDetail = cartDetailServices.GetAllCartDetails().FirstOrDefault(x => x.UserId == users.Id && x.ProductId == IdPro);
                    cartDetail.Quantity = cartDetail.Quantity + 1;
                    cartDetailServices.Update(cartDetail);

                }
                return RedirectToAction("Cart");
                //return View();
            }
        }
        #endregion


        #region Login + SignUp
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string user, string pass)
        {
            Accounts a = accountServices.GetAllAccounts().FirstOrDefault(x => x.UserName == user && x.Password == pass);
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(a));
            if (a != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Accounts accounts)
        {
            if (accountServices.Add(accounts))
                return RedirectToAction("Login");
            else return BadRequest();
        }
        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}