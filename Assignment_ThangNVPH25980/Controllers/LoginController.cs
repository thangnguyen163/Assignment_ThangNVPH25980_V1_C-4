using Assignment_ThangNVPH25980.IService;
using Assignment_ThangNVPH25980.Models;
using Assignment_ThangNVPH25980.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment_ThangNVPH25980.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountServices accountServices;
        public LoginController()
        {
            accountServices = new AccountServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string user, string pass )
        {
            List<Accounts> a=accountServices.GetAllAccounts().Where(x=>x.UserName==user && x.Password==pass).ToList();
            HttpContext.Session.SetString("User",JsonConvert.SerializeObject(a));
            if (a.Count() > 0)
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
    }
}
