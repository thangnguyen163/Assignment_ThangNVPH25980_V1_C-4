using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class ColorServices : IColorServices
    {
        OuteDBContext context;
        public ColorServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(Color color)
        {
            try
            {
                context.Color.Add(color);
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
                var p = context.Color.Find(Id);
                context.Color.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Color> GetAllColor()
        {
            return context.Color.ToList();
        }

        public Color GetColorById(Guid Id)
        {
            return context.Color.FirstOrDefault(x => x.Id == Id);
        }

        public List<Color> GetColorByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Color color)
        {
            try
            {
                var p = context.Color.Find(color.Id);
                p.Name = color.Name;
                p.Status = color.Status;
                context.Color.Update(p);
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
