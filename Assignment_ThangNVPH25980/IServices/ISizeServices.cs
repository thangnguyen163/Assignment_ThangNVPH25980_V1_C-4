
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface ISizeServices
    {
        public bool Add(Size size);
        public bool Update(Size size);
        public bool Delete(Guid Id);
        public List<Size> GetAllSize();
        public Size GetSizeById(Guid Id);
        public List<Size> GetSizeByName(string Name);
    }
}
