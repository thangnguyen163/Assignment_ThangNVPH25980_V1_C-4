using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class CategoryServices : ICategoryServices
    {
        OuteDBContext context;
        public CategoryServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(Category category)
        {
            try
            {
                context.Category.Add(category);
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
                var p = context.Category.Find(Id);
                context.Category.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Category> GetAllCategory()
        {
            return context.Category.ToList();
        }

        public Category GetCategoryById(Guid Id)
        {
            return context.Category.FirstOrDefault(x => x.Id == Id);
        }

        public List<Category> GetCategoryByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category category)
        {
            try
            {
                var p = context.Category.Find(category.Id);
                p.Name= category.Name;
                p.Status= category.Status;
                context.Category.Update(p);
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
