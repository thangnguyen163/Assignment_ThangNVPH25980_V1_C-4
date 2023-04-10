using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface ICategoryServices
    {
        public bool Add(Category category);
        public bool Update(Category category);
        public bool Delete(Guid Id);
        public List<Category> GetAllCategory();
        public Category GetCategoryById(Guid Id);
        public List<Category> GetCategoryByName(string Name);
    }
}
