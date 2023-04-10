
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface IColorServices
    {
        public bool Add(Color color);
        public bool Update(Color color);
        public bool Delete(Guid Id);
        public List<Color> GetAllColor();
        public Color GetColorById(Guid Id);
        public List<Color> GetColorByName(string Name);
    }
}
