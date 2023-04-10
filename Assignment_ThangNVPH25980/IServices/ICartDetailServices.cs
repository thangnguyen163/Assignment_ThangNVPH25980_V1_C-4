using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface ICartDetailServices
    {
        public bool Add(CartDetails cartDetails);
        public bool Update(CartDetails cartDetails);
        public bool Delete(Guid Id);
        public List<CartDetails> GetAllCartDetails();
        public CartDetails GetCartDetailById(Guid Id);
        public List<CartDetails> GetCartDetailByName(string Name);
    }
}
