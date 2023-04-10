using Assignment_ThangNVPH25980.IService;
using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class AccountServices : IAccountServices
    {
        OuteDBContext context;
        private ICartServices cartServices;
        public AccountServices()
        {
            context = new OuteDBContext();
            cartServices = new CartServices();
        }
        public bool Add(Accounts accounts)
        {
            Guid Id= Guid.NewGuid();
            try
            {
                accounts.Id = Id;
                accounts.RoleId = Guid.Parse(Convert.ToString("2975D400-AA9F-4E03-B43A-8C7D93779354"));
                accounts.Status = 1;
                context.Accounts.Add(accounts);
                Cart cart = new Cart();
                cart.UserId = Id;
                cartServices.Add(cart);
                context.SaveChanges();
                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var p = context.Accounts.Find(Id);
                context.Accounts.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Accounts GetAccountById(Guid Id)
        {
            return context.Accounts.FirstOrDefault(x => x.Id == Id);
        }

        public List<Accounts> GetAccountByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Accounts> GetAllAccounts()
        {
            return context.Accounts.ToList();
        }

        public bool Update(Accounts accounts)
        {
            try
            {
                var p = context.Accounts.Find(accounts.Id);
                p.UserName=accounts.UserName;   
                p.Password=accounts.Password;
                p.NumberPhone  =accounts.NumberPhone;
                p.RoleId=accounts.RoleId;
                p.Status =accounts.Status;
                context.Accounts.Update(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
