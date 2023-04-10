using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface ICartServices
    {
        public bool Add(Cart cart);
        public bool Update(Cart cart);
        public bool Delete(Guid Id);
        public List<Cart> GetAllCart();
        public Cart GetCartById(Guid Id);
        public List<Cart> GetCartByName(string Name);
    }
}
