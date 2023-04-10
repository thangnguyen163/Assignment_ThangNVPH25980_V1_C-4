using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class CartServices : ICartServices
    {
        OuteDBContext context;
        public CartServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(Cart cart)
        {
            try
            {
                context.Cart.Add(cart);
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
                var p = context.Cart.Find(Id);
                context.Cart.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cart> GetAllCart()
        {
            return context.Cart.ToList();
        }

        public Cart GetCartById(Guid Id)
        {
            return context.Cart.FirstOrDefault(x => x.UserId == Id);
        }

        public List<Cart> GetCartByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cart cart)
        {
            try
            {
                var p = context.Cart.Find(cart.UserId);
                p.Description=cart.Description;
                p.Status=cart.Status;
                context.Cart.Update(p);
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
