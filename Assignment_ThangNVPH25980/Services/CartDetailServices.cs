using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class CartDetailServices : ICartDetailServices
    {
        OuteDBContext context;
        public CartDetailServices()
        {
            context = new OuteDBContext();
        }

        public bool Add(CartDetails cartDetails)
        {
            try
            {
                context.CartDetails.Add(cartDetails);
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
                var p = context.CartDetails.Find(Id);
                context.CartDetails.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetails> GetAllCartDetails()
        {
            return context.CartDetails.ToList();
        }

        public CartDetails GetCartDetailById(Guid Id)
        {
            return context.CartDetails.FirstOrDefault(x => x.Id == Id);
        }

        public List<CartDetails> GetCartDetailByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(CartDetails cartDetails)
        {
            try
            {
                var p = context.CartDetails.Find(cartDetails.Id);
                p.ProductId=cartDetails.ProductId;
                p.Quantity=cartDetails.Quantity;
                context.CartDetails.Update(p);
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
